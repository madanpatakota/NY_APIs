using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories;

public interface IAppealRightRepository
{
    Task<List<AppealRight>> GetBySectionIdAsync(int sectionId);
}
