namespace Nyayabharat.Application.DTOs.Situation
{
    public class SituationDto
    {
        public int SituationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
    }
}
