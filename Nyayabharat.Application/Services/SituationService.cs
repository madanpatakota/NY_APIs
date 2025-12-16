using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Services
{
    public class SituationService : ISituationService
    {
        private readonly ISituationRepository _situationRepository;

        public SituationService(ISituationRepository situationRepository)
        {
            _situationRepository = situationRepository;
        }

        public async Task<IEnumerable<Situation>> GetAllAsync()
        {
            return await _situationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Situation>> GetBySeverityAsync(SeverityLevel severity)
        {
            return await _situationRepository.GetBySeverityAsync(severity);
        }

        public async Task<Situation?> GetByIdAsync(int situationId)
        {
            return await _situationRepository.GetByIdAsync(situationId);
        }
    }
}
