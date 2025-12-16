using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ISituationService
    {
        Task<IEnumerable<Situation>> GetAllAsync();
        Task<IEnumerable<Situation>> GetBySeverityAsync(SeverityLevel severity);
        Task<Situation?> GetByIdAsync(int situationId);
    }
}
