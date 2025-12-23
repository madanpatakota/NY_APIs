using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class SubSection
    {


        [Key]
        public int SubSectionId { get; set; }
        public int SectionId { get; set; }
        public string? SubSectionLabel { get; set; }
        public string? SubSectionText { get; set; }

        public ICollection<Clause> Clauses { get; set; } = new List<Clause>();
    }
}
