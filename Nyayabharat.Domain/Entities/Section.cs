using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Section
    {

        [Key]
        public int SectionId { get; set; }
        public int ActId { get; set; }
        public int? ChapterId { get; set; }
        public string SectionNumber { get; set; } = string.Empty;
        public string? SectionTitle { get; set; }
        public string? SectionText { get; set; }

        // ✅ ADD THIS
        public Act Act { get; set; } = null!;

        public ICollection<SubSection> SubSections { get; set; } = new List<SubSection>();
        public ICollection<SituationSection> SituationSections { get; set; } = new List<SituationSection>();

    }
}
