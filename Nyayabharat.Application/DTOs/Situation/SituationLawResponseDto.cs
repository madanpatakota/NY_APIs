using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.DTOs.Situation
{
    public class SituationLawResponseDto
    {
        public int SituationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Severity { get; set; } = string.Empty;

        public IEnumerable<Section> ApplicableSections { get; set; } = new List<Section>();
        public IEnumerable<Concept> RelatedConcepts { get; set; } = new List<Concept>();
    }
}
