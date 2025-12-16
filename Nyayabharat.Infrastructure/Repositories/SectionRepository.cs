using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Section>> GetSectionsByActIdAsync(int actId)
        {
            return await _context.Sections
                .Where(s => s.ActId == actId)
                .ToListAsync();
        }

        public async Task<Section?> GetSectionWithDetailsAsync(int sectionId)
        {
            return await _context.Sections
                .Include(s => s.SubSections)
                .ThenInclude(ss => ss.Clauses)
                .FirstOrDefaultAsync(s => s.SectionId == sectionId);
        }

        public async Task<IEnumerable<Section>> GetBySituationIdAsync(int situationId)
        {
            return await _context.SituationSections
                .Where(x => x.SituationId == situationId)
                .Select(x => x.Section)
                .ToListAsync();
        }

    }
}
