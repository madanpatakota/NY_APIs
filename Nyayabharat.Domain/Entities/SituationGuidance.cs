using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nyayabharat.Domain.Entities
{
    public class SituationGuidance
    {
        [Key]
        public int GuidanceId { get; set; }

        public int SituationId { get; set; }

        public int StepOrder { get; set; }

        public string GuidanceText { get; set; } = string.Empty;

        [ForeignKey(nameof(SituationId))]
        public Situation Situation { get; set; }
    }
}
