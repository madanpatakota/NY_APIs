using Nyayabharat.Application.DTOs.Act;
using Nyayabharat.Application.DTOs.Chapter;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Application.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;

        public ChapterService(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<List<ChapterDto>> GetByActIdAsync(int actId)
        {
            var chapters = await _chapterRepository.GetByActIdAsync(actId);

            return chapters.Select(c => new ChapterDto
            {
                ChapterId = c.ChapterId,
                ChapterNumber = c.ChapterNumber,
                ChapterTitle = c.ChapterTitle
            }).ToList();
        }
    }
}
