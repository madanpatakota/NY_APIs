using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories;

public interface IJudgmentRepository
{
    Task<List<Judgment>> GetBySectionIdAsync(int sectionId);
}
