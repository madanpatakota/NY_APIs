using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string? DisplayTitle { get; set; }

        public Explanation? Explanation { get; set; }

        // ✅ ADD THIS
        [ForeignKey(nameof(ActId))]
        public Act Act { get; set; } = null!;

        [ForeignKey(nameof(ChapterId))]
        public Chapter? Chapter { get; set; }

        public ICollection<SectionContent> SectionContents { get; set; } = new List<SectionContent>();
        public ICollection<SectionAmendment> SectionAmendments { get; set; } = new List<SectionAmendment>();


        public ICollection<SubSection> SubSections { get; set; } = new List<SubSection>();
        public ICollection<SituationSection> SituationSections { get; set; } = new List<SituationSection>();

    }
}
