using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nyayabharat.Domain.Entities
{
    [Table("SectionParallelMap")]
    public class SectionParallel
    {
        [Key]
        public int SectionParallelId { get; set; }

        public int OldActId { get; set; }
        public int OldSectionId { get; set; }

        public int NewActId { get; set; }

        // IMPORTANT: must allow NULL (for omitted sections)
        public string? NewSectionNumber { get; set; }

        public string MappingType { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
