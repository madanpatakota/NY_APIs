using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Domain.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int SituationId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public string Difficulty { get; set; } = string.Empty;

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
