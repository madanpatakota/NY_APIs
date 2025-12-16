using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ISituationRepository : IGenericRepository<Situation>
    {
        Task<IEnumerable<Situation>> GetBySeverityAsync(SeverityLevel severity);
    }
}
