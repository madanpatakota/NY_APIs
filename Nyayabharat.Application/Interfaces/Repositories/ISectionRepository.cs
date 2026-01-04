using Nyayabharat.Application.DTOs.Section;
using Nyayabharat.Application.DTOs.Situation;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<IEnumerable<Section>> GetSectionsByActIdAsync(int actId);
        Task<Section?> GetSectionWithDetailsAsync(int sectionId);
        //Task<IEnumerable<Section>> GetBySituationIdAsync(int situationId);
        Task<List<SituationSectionDto>> GetBySituationIdAsync(int situationId);
        Task<List<Situation>> GetSituationsBySectionIdAsync(int sectionId);

        Task<SectionParallelDto?> GetBnsEquivalentAsync(int ipcSectionId);


        // 🔥 ONE METHOD FOR ALL PARALLEL LAWS
        Task<SectionParallelDto?> GetParallelSectionAsync(
            int sectionId,
            string targetActShortName
        );

        Task<IEnumerable<Section>> GetByChapterIdAsync(int chapterId);

        Task<Section?> GetWithDetailsAsync(int sectionId);

        Task<IEnumerable<SectionContent>> GetContentsBySectionIdAsync(int sectionId);

    }
}
