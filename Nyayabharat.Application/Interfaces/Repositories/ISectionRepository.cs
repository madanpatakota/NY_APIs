using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<IEnumerable<Section>> GetSectionsByActIdAsync(int actId);
        Task<Section?> GetSectionWithDetailsAsync(int sectionId);
        Task<IEnumerable<Section>> GetBySituationIdAsync(int situationId);

    }
}
