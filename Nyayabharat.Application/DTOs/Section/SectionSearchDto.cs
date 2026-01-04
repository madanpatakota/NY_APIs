namespace Nyayabharat.Application.DTOs.Section
{
    public class SectionSearchDto
    {
        public int SectionId { get; set; }

        public string SectionNumber { get; set; } = string.Empty;

        public string? SectionTitle { get; set; }

        public string ActShortName { get; set; } = string.Empty;   // IPC / BNS

        public int ActId { get; set; }

        public int? ChapterId { get; set; }

        // Highlighted snippet for UI
        public string? MatchSnippet { get; set; }
    }
}
