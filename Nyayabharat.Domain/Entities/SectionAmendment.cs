using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class SectionAmendment
    {

        public int SectionId { get; set; }
        public int AmendmentId { get; set; }

        public Section Section { get; set; } = null!;
        public Amendment Amendment { get; set; } = null!;
    }
}
