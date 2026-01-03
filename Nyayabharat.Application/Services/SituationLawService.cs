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
        private readonly ISituationGuidanceRepository _guidanceRepository;


        public SituationLawService(
            ISituationRepository situationRepository,
            ISectionRepository sectionRepository,
            IConceptRepository conceptRepository,
            ISituationGuidanceRepository guidanceRepository)
        {
            _situationRepository = situationRepository;
            _sectionRepository = sectionRepository;
            _conceptRepository = conceptRepository;

            _guidanceRepository = guidanceRepository;
        }

        //public async Task<SituationLawResponseDto?> GetLawBySituationAsync(int situationId)
        //{
        //    var situation = await _situationRepository.GetByIdAsync(situationId);
        //    if (situation == null) return null;

        //    var sections = await _sectionRepository.GetBySituationIdAsync(situationId);
        //    var concepts = await _conceptRepository.GetBySituationIdAsync(situationId);

        //    return new SituationLawResponseDto
        //    {
        //        SituationId = situation.SituationId,
        //        Title = situation.Title,
        //        Description = situation.Description,
        //        Severity = situation.Severity.ToString(),
        //        ApplicableSections = sections,
        //        RelatedConcepts = concepts
        //    };
        //}


        //public async Task<SituationLawResponseDto?> GetLawBySituationAsync(int situationId)
        //{
        //    var situation = await _situationRepository.GetByIdAsync(situationId);
        //    if (situation == null) return null;

        //    var sections = await _sectionRepository.GetBySituationIdAsync(situationId);
        //    var concepts = await _conceptRepository.GetBySituationIdAsync(situationId);

        //    return new SituationLawResponseDto
        //    {
        //        SituationId = situation.SituationId,
        //        Title = situation.Title,
        //        Description = situation.Description,
        //        Severity = situation.Severity.ToString(),

        //        ApplicableSections = sections.Select(s => new SituationSectionDto
        //        {
        //            SectionId = s.SectionId,
        //            SectionNumber = s.SectionNumber,
        //            SectionTitle = s.SectionTitle,
        //            ActShortName = s.ActShortName
        //        }).ToList(),

        //        RelatedConcepts = concepts.Select(c => new SituationConceptDto
        //        {
        //            ConceptId = c.ConceptId,
        //            ConceptName = c.ConceptName,
        //            SimpleDefinition = c.SimpleDefinition
        //        }).ToList()
        //    };
        //}

        public async Task<SituationLawResponseDto?> GetLawBySituationAsync(int situationId)
        {
            var situation = await _situationRepository.GetByIdAsync(situationId);
            //var guidance = await _guidanceRepository.GetBySituationIdAsync(situationId);

            if (situation == null) return null;

            var sections = await _sectionRepository.GetBySituationIdAsync(situationId);
            var concepts = await _conceptRepository.GetBySituationIdAsync(situationId);
            var guidance = await _guidanceRepository.GetBySituationIdAsync(situationId);

            return new SituationLawResponseDto
            {
                SituationId = situation.SituationId,
                Title = situation.Title,
                Description = situation.Description,
                Severity = situation.Severity.ToString(),

                ApplicableSections = sections.Select(s => new SituationSectionDto
                {
                    SectionId = s.SectionId,
                    SectionNumber = s.SectionNumber,
                    SectionTitle = s.SectionTitle,
                    ActShortName = s.ActShortName
                }).ToList(),

                RelatedConcepts = concepts.Select(c => new SituationConceptDto
                {
                    ConceptId = c.ConceptId,
                    ConceptName = c.ConceptName,
                    SimpleDefinition = c.SimpleDefinition
                }).ToList(),

                Guidance = guidance.Select(g => new SituationGuidanceDto
                {
                    StepOrder = g.StepOrder,
                    GuidanceText = g.GuidanceText
                }).ToList()
            };
        }

    }
}
