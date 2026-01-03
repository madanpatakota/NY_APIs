using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nyayabharat.Domain.Entities
{
    public class Act
    {
        [Key]
        public int ActId { get; set; }

        public string ActName { get; set; } = string.Empty;
        public string? ActShortName { get; set; }

        // OLD (temporary – can be removed later)
        public string? ActType { get; set; }

        public int EnactedYear { get; set; }
        public string? Authority { get; set; }
        public string Status { get; set; } = "Active";

        // ✅ NEW (MAIN RELATION)
        public int? ActCategoryId { get; set; }


        // ✅ ADD THIS
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

        [ForeignKey(nameof(ActCategoryId))]
        public ActCategory? ActCategory { get; set; }
    }
}
