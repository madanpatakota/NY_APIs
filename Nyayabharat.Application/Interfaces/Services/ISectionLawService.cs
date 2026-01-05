using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services;

public interface ISectionLawService
{
    Task<List<Judgment>> GetJudgments(int sectionId);
    Task<List<AppealRight>> GetAppealRights(int sectionId);
    Task BookmarkSection(int userId, int sectionId);
}
