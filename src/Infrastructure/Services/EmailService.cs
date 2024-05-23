using MimeKit;
using MailKit.Net.Smtp;

namespace Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendEmail(string request);
        void SendEmailOTP(OTP request);
        void SendSchedule(ScheduleMail request);
        void SendTreatment(ScheduleMail request);
    }
    public class CEmailService : IEmailService
    {
        private readonly IRepository<SendEmail> _repository;
        public CEmailService(IRepository<SendEmail> repository)
        { 
            _repository = repository;
        }

        public async Task SendEmail(string request)
        {
            MailRequest mailRequest = new MailRequest
            {
                From = "hungtq1016@gmail.com",
                To = request, // Make sure 'request' contains a valid email address
                Subject = "Change your password",
                Body = "We have processed your password change request. If you are the one who submitted this request, please click on the link below to change your password."
            };

            Guid id = Guid.NewGuid();
                
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("AkiAki Clinic", mailRequest.From));

            // Make sure 'request' contains a valid email address
            if (IsValidEmail(request))
            {
                email.To.Add(new MailboxAddress("Gửi", request));
            }
            else
            {
                // Handle invalid email address (log, throw exception, etc.)
                Console.WriteLine($"Invalid email address: {request}");
                return;
            }

            email.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = TemplateMail(mailRequest, id.ToString());
            email.Body = bodyBuilder.ToMessageBody();


            using (var smtp = new SmtpClient())
            {
                await _repository.AddAsync(new SendEmail { Id = id, Email = request, ExpiredTime = DateTime.UtcNow.AddMinutes(30) });

                smtp.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("hungbanghung@gmail.com", "game qutq paai kazq");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public void SendEmailOTP(OTP request)
        {
            MailRequest mailRequest = new MailRequest
            {
                From = "hungtq1016@gmail.com",
                To = request.Email, // Make sure 'request' contains a valid email address
                Subject = "One time password",
                Body = ""
            };

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("AkiAki Clinic", mailRequest.From));

            // Make sure 'request' contains a valid email address
            if (IsValidEmail(request.Email))
            {
                email.To.Add(new MailboxAddress("Gửi", request.Email));
            }
            else
            {
                // Handle invalid email address (log, throw exception, etc.)
                Console.WriteLine($"Invalid email address: {request.Email}");
                return;
            }

            email.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = TemplateMailOTP(request);
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("hungbanghung@gmail.com", "game qutq paai kazq");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public void SendSchedule(ScheduleMail request)
        {
            MailRequest mailRequest = new MailRequest
            {
                From = "hungtq1016@gmail.com",
                To = request.Email, // Make sure 'request' contains a valid email address
                Subject = "Xác nhận email",
                Body = ""
            };

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("AkiAki Clinic", mailRequest.From));

            // Make sure 'request' contains a valid email address
            if (IsValidEmail(request.Email))
            {
                email.To.Add(new MailboxAddress("Gửi", request.Email));
            }
            else
            {
                // Handle invalid email address (log, throw exception, etc.)
                Console.WriteLine($"Invalid email address: {request.Email}");
                return;
            }

            email.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();
            string template = $"<p>Xin chào {request.Email} vui lòng kiểm tra điện thoại/email để nhận thông tin mới nhất nhá</p>";
            bodyBuilder.HtmlBody = TemplateMail(template);
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("hungbanghung@gmail.com", "game qutq paai kazq");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public void SendTreatment(ScheduleMail request)
        {
            MailRequest mailRequest = new MailRequest
            {
                From = "hungtq1016@gmail.com",
                To = request.Email, // Make sure 'request' contains a valid email address
                Subject = "Kế hoạch điều trị",
                Body = ""
            };

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("AkiAki Clinic", mailRequest.From));

            // Make sure 'request' contains a valid email address
            if (IsValidEmail(request.Email))
            {
                email.To.Add(new MailboxAddress("Gửi", request.Email));
            }
            else
            {
                // Handle invalid email address (log, throw exception, etc.)
                Console.WriteLine($"Invalid email address: {request.Email}");
                return;
            }

            email.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();
            string template = @$"<div>
                    <p>Xin chào {request.Email} vui lòng kiểm tra theo đúng lịch.</p>
                       <ul> {request.Template}</ul>
                    </div>";
            bodyBuilder.HtmlBody = TemplateMail(template);
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("hungbanghung@gmail.com", "game qutq paai kazq");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string TemplateMail(MailRequest request, string id)
        {
            return @$"<div style=""box-sizing:inherit;margin:0;color:rgba(0,0,0,0.87);font-family:'Roboto','Helvetica','Arial',sans-serif;font-weight:400;font-size:1rem;line-height:1.5;letter-spacing:0.00938em;background-color:#000000""><div class=""adM"">
                    </div><div style=""box-sizing:inherit;font-weight:400;font-size:16px;padding:32px 0;margin:0;letter-spacing:0.15008px;line-height:1.5;background-color:#000000;font-family:'Iowan Old Style','Palatino Linotype','URW Palladio L',P052,serif;color:#ffffff""><div class=""adM"">
                      </div><div id=""m_6480876213820302322__react-email-preview"" style=""box-sizing:inherit;display:none;overflow:hidden;line-height:1px;opacity:0;max-height:0;max-width:0"">This code will expire in 30 minutes.<div style=""box-sizing:inherit"">&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏<wbr>﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌<wbr>​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍<wbr>‎‏﻿&nbsp;‌​‍‎‏﻿</div>
                      </div>
                      <table align=""center"" width=""100%"" style=""box-sizing:inherit;background-color:#000000;max-width:600px;min-height:48px"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" bgcolor=""#000000"">
                        <tbody style=""box-sizing:inherit; color: 'white'"">
                          <tr style=""box-sizing:inherit;width:100%"">
                            <td style=""box-sizing:inherit"">
                              <div style=""color:#ffffff;font-family:inherit;font-size:16px;font-weight:normal;padding:16px 24px 16px 24px;text-align:center;max-width:100%;box-sizing:border-box"">

                                <div style=""box-sizing:inherit"">
                                  <div style=""box-sizing:inherit"">
                                    <p style=""box-sizing:inherit;margin-top:0px;margin-bottom:0px"">We have processed your password change request.<br/> If you are the one who submitted this request,<br/> please click on the link below to change your password.</p>
                                  </div>
                                </div>
                              </div>
                              <div style=""font-family:inherit;font-weight:bold;padding:16px 24px 16px 24px;text-align:center;max-width:100%;box-sizing:border-box"">
                                <a href=""http://localhost:5173/oauth2/reset-password?id={id}&email={request.To}"" style=""background:#00466a;margin:0 auto;width:max-content;padding:8px 14px;color:#fff;border-radius:4px; text-decoration: none; font-size: 24px;"">Change password</a>
                            </div>
                              <div style=""color:#868686;font-family:inherit;font-size:14px;font-weight:normal;padding:16px 24px 16px 24px;text-align:center;max-width:100%;box-sizing:border-box"">
                                <div style=""box-sizing:inherit"">
                                  <div style=""box-sizing:inherit"">
                                    <p style=""box-sizing:inherit;margin-top:0px;margin-bottom:0px""><em style=""box-sizing:inherit"">Problems? Just reply to <a href=""mailto:hungbanghung@gmail.com"" target=""_blank"" jslog=""32272; 1:WyIjdGhyZWFkLWY6MTc5MzA0NTQ1MDA1NzQxOTE3NiJd; 4:WyIjbXNnLWY6MTc5MzA0NjQyOTk2NjczMjEyMiJd"">this email</a>.</em></p>
                                  </div>
                                </div>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table><div class=""yj6qo""></div><div class=""adL"">
                    </div></div><div class=""adL"">
                    </div></div>";
        }

        private string TemplateMailOTP(OTP request)
        {
            return @$"<div style=""box-sizing: inherit; margin: 0; color: rgba(0, 0, 0, 0.87); font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif; font-weight: 400; font-size: 1rem; line-height: 1.5; letter-spacing: 0.00938em; background-color: #000000;"">
                  <div class=""MuiBox-root css-1p9u5cx"" style=""box-sizing: inherit; font-weight: 400; font-size: 16px; padding: 32px 0; margin: 0; letter-spacing: 0.15008px; line-height: 1.5; background-color: #000000; font-family: 'Iowan Old Style', 'Palatino Linotype', 'URW Palladio L', P052, serif; color: #ffffff;"">
                    <div id=""__react-email-preview"" style=""box-sizing: inherit; display: none; overflow: hidden; line-height: 1px; opacity: 0; max-height: 0; max-width: 0;"">This code will expire in 5 minutes.<div style=""box-sizing: inherit;"">&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿</div>
                    </div>
                    <table align=""center"" width=""100%"" style=""box-sizing: inherit; background-color: #000000; max-width: 600px; min-height: 48px;"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" bgcolor=""#000000"">
                      <tbody style=""box-sizing: inherit;"">
                        <tr style=""box-sizing: inherit; width: 100%;"">
                          <td style=""box-sizing: inherit;"">
                            <div style=""color: #ffffff; font-family: inherit; font-size: 16px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
              
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                                  <p style=""box-sizing: inherit; margin-top: 0px; margin-bottom: 0px;"">Here is your one-time passcode:</p>
                                </div>
                              </div>
                            </div>
                            <div style=""font-family: inherit; font-weight: bold; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              <h1 style=""box-sizing: inherit; margin-top: 40px; margin-bottom: 16px; font-weight: inherit; margin: 0; font-size: 32px;"">{request.Code}</h1>
                            </div>
                            <div style=""color: #868686; font-family: inherit; font-size: 16px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                                  <p style=""box-sizing: inherit; margin-top: 0px; margin-bottom: 0px;"">This code will expire in 5 minutes.</p>
                                </div>
                              </div>
                            </div>
                            <div style=""color: #868686; font-family: inherit; font-size: 14px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                                  <p style=""box-sizing: inherit; margin-top: 0px; margin-bottom: 0px;""><em style=""box-sizing: inherit;"">Problems? Just reply to <a href=""mailto:hungbanghung@gmail.com"">this email</a>.</em></p>
                                </div>
                              </div>
                            </div>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>";
        }


        private string TemplateMail(string template)
        {
            return @$"<div style=""box-sizing: inherit; margin: 0; color: rgba(0, 0, 0, 0.87); font-family: 'Roboto', 'Helvetica', 'Arial', sans-serif; font-weight: 400; font-size: 1rem; line-height: 1.5; letter-spacing: 0.00938em; background-color: #000000;"">
                  <div class=""MuiBox-root css-1p9u5cx"" style=""box-sizing: inherit; font-weight: 400; font-size: 16px; padding: 32px 0; margin: 0; letter-spacing: 0.15008px; line-height: 1.5; background-color: #000000; font-family: 'Iowan Old Style', 'Palatino Linotype', 'URW Palladio L', P052, serif; color: #ffffff;"">
                    <div id=""__react-email-preview"" style=""box-sizing: inherit; display: none; overflow: hidden; line-height: 1px; opacity: 0; max-height: 0; max-width: 0;"">This code will expire in 5 minutes.<div style=""box-sizing: inherit;"">&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿&nbsp;‌​‍‎‏﻿</div>
                    </div>
                    <table align=""center"" width=""100%"" style=""box-sizing: inherit; background-color: #000000; max-width: 600px; min-height: 48px;"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" bgcolor=""#000000"">
                      <tbody style=""box-sizing: inherit;"">
                        <tr style=""box-sizing: inherit; width: 100%;"">
                          <td style=""box-sizing: inherit;"">
                            <div style=""color: #ffffff; font-family: inherit; font-size: 16px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
              
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                            
                                </div>
                              </div>
                            </div>
                            <div style=""font-family: inherit; font-weight: bold; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              {template}
                            </div>
                            <div style=""color: #868686; font-family: inherit; font-size: 16px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                                </div>
                              </div>
                            </div>
                            <div style=""color: #868686; font-family: inherit; font-size: 14px; font-weight: normal; padding: 16px 24px 16px 24px; text-align: center; max-width: 100%; box-sizing: border-box;"">
                              <div class=""MuiBox-root css-vii0ua"" style=""box-sizing: inherit;"">
                                <div style=""box-sizing: inherit;"">
                                  <p style=""box-sizing: inherit; margin-top: 0px; margin-bottom: 0px;""><em style=""box-sizing: inherit;"">Problems? Just reply to <a href=""mailto:hungbanghung@gmail.com"">this email</a>.</em></p>
                                </div>
                              </div>
                            </div>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>";
        }
    }
}
