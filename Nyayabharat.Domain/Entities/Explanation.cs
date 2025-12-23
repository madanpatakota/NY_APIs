using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Explanation
    {
        [Key]
        public int QuestionId { get; set; }
        public string? SimpleExplanation { get; set; }
        public string? LegalExplanation { get; set; }
    }
}
