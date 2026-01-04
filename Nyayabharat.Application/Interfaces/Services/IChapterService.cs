using Nyayabharat.Application.DTOs.Act;
using Nyayabharat.Application.DTOs.Chapter;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IChapterService
    {
        Task<List<ChapterDto>> GetByActIdAsync(int actId);
    }
}
