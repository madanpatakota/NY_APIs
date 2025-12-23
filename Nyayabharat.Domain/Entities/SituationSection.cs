using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class SituationSection
    {


        [Key]
        public int SituationId { get; set; }
        public int SectionId { get; set; }

        public Situation Situation { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}
