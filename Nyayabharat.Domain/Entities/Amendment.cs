using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Amendment
    {

        [Key]
        public int AmendmentId { get; set; }
        public int ActId { get; set; }
        public int AmendmentYear { get; set; }
        public string? Description { get; set; }
        public DateTime EffectiveFrom { get; set; }
    }
}
