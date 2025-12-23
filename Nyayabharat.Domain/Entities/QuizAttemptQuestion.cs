using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class QuizAttemptQuestion
    {

        [Key]
        public int AttemptQuestionId { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
    }
}
