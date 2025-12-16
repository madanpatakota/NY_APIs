namespace Nyayabharat.Domain.Entities
{
    public class Act
    {
        public int ActId { get; set; }
        public string ActName { get; set; } = string.Empty;
        public string? ActShortName { get; set; }
        public string? ActType { get; set; }
        public int EnactedYear { get; set; }
        public string? Authority { get; set; }
        public string Status { get; set; } = "Active";
    }
}
