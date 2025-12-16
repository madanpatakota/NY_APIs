using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IConceptRepository : IGenericRepository<Concept>
    {
        Task<IEnumerable<Concept>> GetBySituationIdAsync(int situationId);
    }
}
