using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.DTOs.Section;
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


        public async Task<SectionParallelDto?> GetBnsEquivalentAsync(int ipcSectionId)
        {
            var bnsActId = await _context.Acts
                .Where(a => a.ActShortName == "BNS")
                .Select(a => a.ActId)
                .FirstAsync();

            return await (
                from pm in _context.SectionParallelMap
                join ipc in _context.Sections on pm.OldSectionId equals ipc.SectionId
                join bns in _context.Sections
                    on pm.NewSectionNumber equals bns.SectionNumber into bnsJoin
                from bns in bnsJoin.DefaultIfEmpty()
                where pm.OldSectionId == ipcSectionId
                      && pm.NewActId == bnsActId
                select new SectionParallelDto
                {
                    IpcSectionId = ipc.SectionId,
                    IpcSectionNumber = ipc.SectionNumber,
                    MappingType = pm.MappingType,
                    BnsSectionId = bns != null ? bns.SectionId : null,
                    BnsSectionNumber = pm.NewSectionNumber,
                    BnsSectionTitle = bns != null ? bns.SectionTitle : null,
                    Notes = pm.Notes
                }
            ).FirstOrDefaultAsync();
        }

        public async Task<SectionParallelDto?> GetParallelSectionAsync(
    int sectionId,
    string targetActShortName)
        {
            var targetActId = await _context.Acts
                .Where(a => a.ActShortName == targetActShortName)
                .Select(a => a.ActId)
                .FirstOrDefaultAsync();

            if (targetActId == 0) return null;

            return await (
                from pm in _context.SectionParallelMap
                join src in _context.Sections
                    on pm.OldSectionId equals src.SectionId
                join tgt in _context.Sections
                    on pm.NewSectionNumber equals tgt.SectionNumber
                    into tgtJoin
                from tgt in tgtJoin.DefaultIfEmpty()
                where pm.OldSectionId == sectionId
                      && pm.NewActId == targetActId
                select new SectionParallelDto
                {
                    IpcSectionId = src.SectionId,
                    IpcSectionNumber = src.SectionNumber,

                    BnsSectionId = tgt != null ? tgt.SectionId : null,
                    BnsSectionNumber = pm.NewSectionNumber,
                    BnsSectionTitle = tgt != null ? tgt.SectionTitle : null,

                    MappingType = pm.MappingType,
                    Notes = pm.Notes
                }
            ).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Section>> GetByChapterIdAsync(int chapterId)
        {
            try
            {
                return await _context.Sections
                    .Where(s => s.ChapterId == chapterId)
                    .OrderBy(s => s.SectionNumber)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }



        public async Task<Section?> GetWithDetailsAsync(int sectionId)
        {
            return await _context.Sections
                .Include(s => s.Act)
                .Include(s => s.Chapter)
                .Include(s => s.SectionAmendments)
                    .ThenInclude(sa => sa.Amendment)
                .Include(s => s.SectionContents)
                .FirstOrDefaultAsync(s => s.SectionId == sectionId);
        }


        public async Task<IEnumerable<SectionContent>> GetBySectionIdAsync(int sectionId)
        {
            return await _context.SectionContents
                .Where(c => c.SectionId == sectionId)
                .OrderBy(c => c.ContentType)
                .ToListAsync();
        }


        public async Task<IEnumerable<SectionContent>> GetContentsBySectionIdAsync(int sectionId)
        {
            return await _context.SectionContents
                .Where(c => c.SectionId == sectionId)
                .OrderBy(c => c.ContentType)
                .ToListAsync();
        }

    }
}
