using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<string?> GetTranslatedTextAsync(
            string entityType,
            int entityId,
            string languageCode);

        Task<string?> GetTranslatedTextAsync(
        string entityType,
        int entityId,
        string fieldName,
        string languageCode);


        Task<List<TranslationBulkResponse>> GetBulkAsync(
    string entityType,
    int entityId,
    List<string> fieldNames,
    string languageCode);


    }
}
