using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.DTOs.Section;
using Nyayabharat.Application.DTOs.Situation;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IEnumerable<Section>> GetByActIdAsync(int actId)
        {
            return await _sectionRepository.GetSectionsByActIdAsync(actId);
        }

        public async Task<Section?> GetWithDetailsAsync(int sectionId)
        {
            return await _sectionRepository.GetSectionWithDetailsAsync(sectionId);
        }

        public async Task<List<SituationDto>> GetSituationsBySectionAsync(int sectionId)
        {
            var situations = await _sectionRepository.GetSituationsBySectionIdAsync(sectionId);

            return situations.Select(s => new SituationDto
            {
                SituationId = s.SituationId,
                Title = s.Title,
                Severity = s.Severity.ToString()
            }).ToList();
        }

        public async Task<SectionParallelDto?> GetBnsEquivalentAsync(int ipcSectionId)
        {
            return await _sectionRepository.GetBnsEquivalentAsync(ipcSectionId);
        }

        public async Task<SectionParallelDto?> GetParallelSectionAsync(
     int sectionId,
     string targetActShortName)
        {
            return await _sectionRepository
                .GetParallelSectionAsync(sectionId, targetActShortName);
        }



    }
}
