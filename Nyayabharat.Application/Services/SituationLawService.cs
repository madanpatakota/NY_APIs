using Nyayabharat.Application.DTOs.Situation;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Application.Services
{
    public class SituationLawService : ISituationLawService
    {
        private readonly ISituationRepository _situationRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IConceptRepository _conceptRepository;

        public SituationLawService(
            ISituationRepository situationRepository,
            ISectionRepository sectionRepository,
            IConceptRepository conceptRepository)
        {
            _situationRepository = situationRepository;
            _sectionRepository = sectionRepository;
            _conceptRepository = conceptRepository;
        }

        public async Task<SituationLawResponseDto?> GetLawBySituationAsync(int situationId)
        {
            var situation = await _situationRepository.GetByIdAsync(situationId);
            if (situation == null) return null;

            var sections = await _sectionRepository.GetBySituationIdAsync(situationId);
            var concepts = await _conceptRepository.GetBySituationIdAsync(situationId);

            return new SituationLawResponseDto
            {
                SituationId = situation.SituationId,
                Title = situation.Title,
                Description = situation.Description,
                Severity = situation.Severity.ToString(),
                ApplicableSections = sections,
                RelatedConcepts = concepts
            };
        }
    }
}
