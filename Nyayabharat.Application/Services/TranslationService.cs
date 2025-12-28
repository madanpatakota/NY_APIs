using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

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


        public async Task<string?> GetTranslatedTextAsync(
        string entityType,
        int entityId,
        string fieldName,
        string languageCode)
        {
            var translation = await _translationRepository.GetAsync(
                entityType, entityId, fieldName, languageCode);

            return translation?.TranslatedText;
        }

        /// <summary>
        /// Get multiple translated texts in one call (BULK)
        /// </summary>
        public async Task<List<TranslationBulkResponse>> GetBulkAsync(
            string entityType,
            int entityId,
            List<string> fieldNames,
            string languageCode)
        {
            if (fieldNames == null || fieldNames.Count == 0)
                return new List<TranslationBulkResponse>();

            return await _translationRepository.GetBulkAsync(
                entityType,
                entityId,
                fieldNames,
                languageCode);
        }
    }
}
