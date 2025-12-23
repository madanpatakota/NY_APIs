using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class QuizAttemptAnswer
    {
        [Key]
        public int AttemptAnswerId { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
