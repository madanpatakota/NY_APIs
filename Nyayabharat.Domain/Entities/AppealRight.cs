namespace Nyayabharat.Domain.Entities;

public class AppealRight
{
    public int AppealRightId { get; set; }
    public int SectionId { get; set; }
    public string AppealCourt { get; set; }
    public string TimeLimit { get; set; }
    public string Notes { get; set; }
}
