using Nyayabharat.Application.DTOs.Section;
using Nyayabharat.Application.DTOs.Situation;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetByActIdAsync(int actId);
        Task<Section?> GetWithDetailsAsync(int sectionId);

        Task<List<SituationDto>> GetSituationsBySectionAsync(int sectionId);

        Task<SectionParallelDto?> GetBnsEquivalentAsync(int ipcSectionId);

        Task<SectionParallelDto?> GetParallelSectionAsync(
    int sectionId,
    string targetActShortName
);



    }
}
