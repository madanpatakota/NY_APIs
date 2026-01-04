namespace Nyayabharat.Application.DTOs.Section
{
    public class SectionDto
    {
        public int SectionId { get; set; }

        public string SectionNumber { get; set; } = string.Empty;

        public string? SectionTitle { get; set; }

        public int ActId { get; set; }

        public int? ChapterId { get; set; }
    }
}
