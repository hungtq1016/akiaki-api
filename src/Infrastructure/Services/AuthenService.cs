using Core.Models;

namespace Infrastructure.Services
{
    public interface IAuthenService
    {
        Task<Core.Response<TokenResponse>> LoginAsync(LoginRequest request);
        Task<Core.Response<UserResponse>> GetUserAsync(HttpContext context);
        Task<Core.Response<TokenResponse>> RegisterAsync(RegisterRequest request);
        Task<Core.Response<string>> SendEmailAsync(EmailRequest request);
        Task<Core.Response<bool>> EmailVaidAsync(EmailValidRequest request);
        Task<Core.Response<bool>> SendResetPasswordAsync(ResetPasswordRequest request);
        Task<Core.Response<bool>> SendOTPAsync(string email);
        Task<Core.Response<TokenResponse>> ReceiveOTPAsync(OTPRequest request);
        Task<Core.Response<TokenResponse>> GenerateAccessToken(Guid userId);
        Task<Core.Response<TokenResponse>> RefreshAccessToken(TokenRequest request);
    }
    public class AuthenService : IAuthenService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<OTP> _otpRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<SendEmail> _mailRepository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AuthenService(ITokenService tokenService, IEmailService emailService, IRepository<User> userRepository, IMapper mapper, IRepository<OTP> otpRepository, 
            IRepository<Role> roleRepository, IRepository<Group> groupRepository, IRepository<SendEmail> mailRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _mapper = mapper;
            _otpRepository = otpRepository;
            _emailService = emailService;
            _roleRepository = roleRepository;
            _groupRepository = groupRepository;
            _mailRepository = mailRepository;
        }

        public async Task<Core.Response<TokenResponse>> LoginAsync(LoginRequest request)
        {
            User user = await FindByEmailAsync(request.Email);

            if (user is null || !BC.Verify(request.Password, user.Password))
            {
                return ResponseHelper.CreateNotFoundResponse<TokenResponse>("Email or Password is invalid!");
            }

            return ResponseHelper.CreateSuccessResponse(await _tokenService.GetTokenResponseAsync(user));
        }

        public async Task<Core.Response<TokenResponse>> RegisterAsync(RegisterRequest request)
        {
            if (await FindByEmailAsync(request.Email) is not null)
                return ResponseHelper.CreateErrorResponse<TokenResponse>(409, "Email is already exists");

            var user = _mapper.Map<User>(request);
            user.Password = BC.HashPassword(user.Password);

            Role role = await _roleRepository.FindOneAsync(new Expression<Func<Role, bool>>[]
                                                            {
                                                                e => e.Name.Contains("Customer")
                                                            }) ??
                        await _roleRepository.AddAsync(new Role { Name = "Customer", Note = "Customer role" });

            var group = new Group { RoleId = role.Id, UserId = (await _userRepository.AddAsync(user)).Id };

            await _groupRepository.AddAsync(group);

            return ResponseHelper.CreateCreatedResponse(await _tokenService.GetTokenResponseAsync(user));
        }


        public async Task<Core.Response<TokenResponse>> GenerateAccessToken(Guid userId)
        {
            User user = await _userRepository.FindByIdAsync(userId);

            if (user is null)
            {
                return ResponseHelper.CreateErrorResponse<TokenResponse>(409, "User not found");
            }

            return ResponseHelper.CreateSuccessResponse(await _tokenService.GetTokenResponseAsync(user));
        }

        public async Task<Core.Response<TokenResponse>> RefreshAccessToken(TokenRequest request)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredAccessToken(request.AccessToken);

            Guid userId = Guid.Parse(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return await GenerateAccessToken(userId);
        }

        public async Task<Core.Response<string>> SendEmailAsync(EmailRequest request)
        {

            await _emailService.SendEmail(request.Email);

            return ResponseHelper.CreateSuccessResponse("You will receive an email if the address is valid.");
        }

        public async Task<Core.Response<bool>> EmailVaidAsync(EmailValidRequest request)
        {
            SendEmail response = await _mailRepository.FindOneByConditionAsync(new Expression<Func<SendEmail, bool>>[]
                                                            {
                                                                e => e.Email == request.Email &&
                                                                e.ExpiredTime > DateTime.UtcNow &&
                                                                e.Status == StatusEnum.Active &&
                                                                e.Id == request.Id 
                                                            });
            if (response is null)
                return ResponseHelper.CreateNotFoundResponse<bool>("Expired time");

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<bool>> SendResetPasswordAsync(ResetPasswordRequest request)
        {
            User userEmail = await FindByEmailAsync(request.Email);

            if (userEmail is null)
            {
                return ResponseHelper.CreateNotFoundResponse<bool>("Email not found!");
            }

            SendEmail response = await _mailRepository.FindByIdAsync(request.Id);

            response.Status = StatusEnum.Remove;

            await _mailRepository.EditAsync(response);

            userEmail.Password = BC.HashPassword(request.Password);

            await _userRepository.EditAsync(userEmail);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<bool>> SendOTPAsync(string email)
        {
            User userEmail = await FindByEmailAsync(email);

            if (userEmail is null)
            {
                return ResponseHelper.CreateNotFoundResponse<bool>("Email not found!");
            }

            int code = GenerateOTP();

            OTP otp = new OTP
            {
                Email = email,
                Code = code,
                ExpiredTime = DateTime.UtcNow.AddMinutes(5)
            };

            _emailService.SendEmailOTP(otp);

            await _otpRepository.AddAsync(otp);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<TokenResponse>> ReceiveOTPAsync(OTPRequest request)
        {
            OTP response = await _otpRepository.FindOneAsync(conditions: new Expression<Func<OTP, bool>>[]
                                                        {
                                                           otp => otp.Email == request.Email 
                                                           && otp.Code == request.OTP
                                                           && otp.ExpiredTime > DateTime.UtcNow
                                                           && otp.Status == StatusEnum.Active
                                                        });
            if (response is null)
            {
                return ResponseHelper.CreateNotFoundResponse<TokenResponse>("Expired time");
            }

            User user = await FindByEmailAsync(response.Email);

            response.Status = StatusEnum.Remove;

            await _otpRepository.EditAsync(response);

            return ResponseHelper.CreateSuccessResponse(await _tokenService.GetTokenResponseAsync(user));
        }


        public async Task<Core.Response<UserResponse>> GetUserAsync(HttpContext context)
        {
            // Lấy id từ Claims của người dùng
            string id = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (id == null)
            {
                // Nếu không có id, trả về 404
                return ResponseHelper.CreateNotFoundResponse<UserResponse>(null);
            }

            Guid userId;

            if (!Guid.TryParse(id, out userId))
            {
                // Nếu không thể chuyển đổi id sang Guid, trả về 404
                return ResponseHelper.CreateNotFoundResponse<UserResponse>(null);
            }

            // Tìm người dùng từ id
            User user = await _userRepository.FindByIdAsync(userId);

            if (user == null)
            {
                // Nếu không tìm thấy người dùng, trả về 404
                return ResponseHelper.CreateNotFoundResponse<UserResponse>(null);
            }

            // Map thông tin người dùng sang đối tượng UserResponse
            UserResponse result = _mapper.Map<UserResponse>(user);

            // Trả về thông tin người dùng và mã trạng thái 200
            return ResponseHelper.CreateSuccessResponse(result);
        }

        private async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository
                        .FindOneAsync(conditions: new Expression<Func<User, bool>>[]
                        {
                           user => user.Email == email
                        });
        }

        private int GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp;
        }

    }
}
