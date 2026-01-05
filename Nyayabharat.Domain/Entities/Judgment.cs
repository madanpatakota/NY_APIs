namespace Nyayabharat.Domain.Entities;

public class Judgment
{
    public int JudgmentId { get; set; }
    public string CourtLevel { get; set; }
    public string CaseTitle { get; set; }
    public DateTime JudgmentDate { get; set; }
    public string Summary { get; set; }
}
