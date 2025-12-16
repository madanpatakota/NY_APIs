namespace Nyayabharat.Domain.Entities
{
    public class QuizAttempt
    {
        public int AttemptId { get; set; }
        public int UserId { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
        public string? Difficulty { get; set; }
    }
}
