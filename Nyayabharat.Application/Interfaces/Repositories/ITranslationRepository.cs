using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<Translation?> GetAsync(string entityType, int entityId, string languageCode);

        Task<Translation?> GetAsync(
    string entityType,
    int entityId,
    string fieldName,
    string languageCode);

        Task<List<TranslationBulkResponse>> GetBulkAsync(string entityType,
    int entityId,
    List<string> fieldNames,
    string languageCode);

    }
}
