namespace Nyayabharat.Application.DTOs.Section
{
    public class SectionDetailDto
    {
        public int SectionId { get; set; }

        public string SectionNumber { get; set; } = string.Empty;

        public string? SectionTitle { get; set; }

        public string? SectionText { get; set; }          // Legal text

        public int ActId { get; set; }

        public string ActName { get; set; } = string.Empty;

        public string? ActShortName { get; set; }         // IPC / CrPC

        public int? ChapterId { get; set; }

        public string? ChapterNumber { get; set; }

        public string? ChapterTitle { get; set; }

        // Content (loaded from SectionContent table)
        public string? Explanation { get; set; }

        public string? SimpleExplanation { get; set; }

        // Amendments
        public List<SectionAmendmentDto> Amendments { get; set; } = new();

        // Metadata (future-ready)
        public bool HasQuiz { get; set; }

        public bool HasSituations { get; set; }
    }
}
