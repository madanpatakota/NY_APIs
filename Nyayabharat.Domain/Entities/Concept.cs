using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Concept
    {

        [Key]
        public int ConceptId { get; set; }
        public string ConceptName { get; set; } = string.Empty;
        public string? SimpleDefinition { get; set; }
        public string? LegalDefinition { get; set; }

        public ICollection<ConceptSection> ConceptSections { get; set; } = new List<ConceptSection>();
        public ICollection<SituationConcept> SituationConcepts { get; set; } = new List<SituationConcept>();
    }
}
