using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.DTOs.Situation;
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

        //public async Task<IEnumerable<Section>> GetBySituationIdAsync(int situationId)
        //{

        //    try
        //    {
        //        var data = _context.SituationConcepts.Where(x => x.SituationId == situationId).ToList();

        //        return await _context.SituationSections
        //            .Where(x => x.SituationId == situationId)
        //            .Select(x => x.Section)
        //            .ToListAsync();
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public async Task<List<SituationSectionDto>> GetBySituationIdAsync(int situationId)
        {
            return await _context.SituationSections
                .Where(x => x.SituationId == situationId)
                .Select(x => new SituationSectionDto
                {
                    SectionId = x.Section.SectionId,
                    SectionNumber = x.Section.SectionNumber,
                    SectionTitle = x.Section.SectionTitle,
                    ActShortName = x.Section.Act.ActShortName
                })
                .ToListAsync();
        }



        public async Task<List<Situation>> GetSituationsBySectionIdAsync(int sectionId)
        {
            return await _context.SituationSections
                .Where(x => x.SectionId == sectionId)
                .Select(x => x.Situation)
                .ToListAsync();
        }


    }
}
