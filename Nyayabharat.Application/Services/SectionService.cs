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
    }
}
