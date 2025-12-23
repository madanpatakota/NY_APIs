using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class ConceptSection
    {


        [Key]
        public int ConceptId { get; set; }
        public int SectionId { get; set; }

        public Concept Concept { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}
