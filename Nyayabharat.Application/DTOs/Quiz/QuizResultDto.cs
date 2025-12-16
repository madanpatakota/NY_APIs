namespace Nyayabharat.Application.DTOs.Quiz
{
    public class QuizResultDto
    {
        public int AttemptId { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
    }
}
