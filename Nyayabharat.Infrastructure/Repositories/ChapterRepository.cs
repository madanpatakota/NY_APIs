using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly NyayabharatDbContext _context;

        public ChapterRepository(NyayabharatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chapter>> GetByActIdAsync(int actId)
        {
            return await _context.Chapters
                .Where(c => c.ActId == actId)
                .OrderBy(c => c.ChapterNumber)
                .ToListAsync();
        }
    }
}
