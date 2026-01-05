using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Services;

public class SectionLawService : ISectionLawService
{
    private readonly IJudgmentRepository _judgmentRepository;
    private readonly IAppealRightRepository _appealRightRepository;
    private readonly IUserBookmarkRepository _bookmarkRepository;

    public SectionLawService(
        IJudgmentRepository judgmentRepository,
        IAppealRightRepository appealRightRepository,
        IUserBookmarkRepository bookmarkRepository)
    {
        _judgmentRepository = judgmentRepository;
        _appealRightRepository = appealRightRepository;
        _bookmarkRepository = bookmarkRepository;
    }

    public async Task<List<Judgment>> GetJudgments(int sectionId)
        => await _judgmentRepository.GetBySectionIdAsync(sectionId);

    public async Task<List<AppealRight>> GetAppealRights(int sectionId)
        => await _appealRightRepository.GetBySectionIdAsync(sectionId);

    public async Task BookmarkSection(int userId, int sectionId)
    {
        if (!await _bookmarkRepository.ExistsAsync(userId, sectionId))
        {
            await _bookmarkRepository.AddAsync(userId, sectionId);
        }
    }
}
