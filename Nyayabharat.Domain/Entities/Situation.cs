using Nyayabharat.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Situation
    {

        [Key]
        public int SituationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public SeverityLevel Severity { get; set; }

        public ICollection<SituationSection> SituationSections { get; set; } = new List<SituationSection>();
        public ICollection<SituationConcept> SituationConcepts { get; set; } = new List<SituationConcept>();

    }
}
