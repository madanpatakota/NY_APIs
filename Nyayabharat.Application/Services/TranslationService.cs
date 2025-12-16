using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationService(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public async Task<string?> GetTranslatedTextAsync(
            string entityType,
            int entityId,
            string languageCode)
        {
            var translation = await _translationRepository
                .GetAsync(entityType, entityId, languageCode);

            return translation?.TranslatedText;
        }
    }
}
