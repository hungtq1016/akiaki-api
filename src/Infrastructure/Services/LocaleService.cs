
namespace Infrastructure.Services
{
    public interface ILocaleService : IService<Locale, LocaleRequest, LocaleResponse>
    {
        Task<Core.Response<object>> GetLocales(string langCode);
    }

    public class LocaleService : Service<Locale, LocaleRequest, LocaleResponse>, ILocaleService
    {
        private readonly IRepository<Language> _languageRepository;

        public LocaleService(IRepository<Language> languageRepository, IRepository<Locale> localeRepository, IMapper mapper)
            : base(localeRepository, mapper)
        {
            _languageRepository = languageRepository;
        }

        public Task<Core.Response<LocaleResponse>> FindOneAsync(Expression<Func<Locale, bool>>[] conditions)
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Response<object>> GetLocales(string langCode)
        {
            var languages = await _languageRepository.FindAllByConditionAsync(conditions: new Expression<Func<Language, bool>>[]
                                                                    {
                                                                        g => g.Code == langCode
                                                                    }, properties: "Locales.Key");

            var data = new Dictionary<string, string>();

            foreach (var language in languages)
            {
                foreach (var locale in language.Locales)
                {
                    data[locale.Key.Key] = locale.Value;
                }
            }

            return ResponseHelper.CreateSuccessResponse((object)data);

        }
    }
}