using System.ComponentModel.DataAnnotations.Schema;

namespace Nyayabharat.Domain.Entities;


[Table("SectionJudgmentMap")]   // 👈 EXACT DB TABLE NAME
public class SectionJudgmentMap
{
    public int SectionId { get; set; }
    public int JudgmentId { get; set; }

    public Judgment Judgment { get; set; }
}
