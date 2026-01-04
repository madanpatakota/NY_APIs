namespace Nyayabharat.Application.DTOs.Section
{
    public class SectionAmendmentDto
    {
        public int AmendmentId { get; set; }

        public int AmendmentYear { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime? EffectiveFrom { get; set; }
    }
}
