namespace Nyayabharat.Application.DTOs.Section
{
    public class SectionParallelDto
    {
        public int IpcSectionId { get; set; }
        public string IpcSectionNumber { get; set; } = string.Empty;

        public string MappingType { get; set; } = string.Empty; // Renumbered / Omitted / Merged

        public int? BnsSectionId { get; set; }
        public string? BnsSectionNumber { get; set; }
        public string? BnsSectionTitle { get; set; }

        public string? Notes { get; set; }
    }
}
