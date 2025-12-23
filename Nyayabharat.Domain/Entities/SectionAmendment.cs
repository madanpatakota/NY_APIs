using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class SectionAmendment
    {

        [Key]
        public int SectionId { get; set; }
        public int AmendmentId { get; set; }
    }
}
