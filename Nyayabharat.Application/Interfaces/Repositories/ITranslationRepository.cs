using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<Translation?> GetAsync(string entityType, int entityId, string languageCode);
    }
}
