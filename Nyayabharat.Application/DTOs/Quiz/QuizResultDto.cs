namespace Nyayabharat.Application.DTOs.Quiz
{
    public class QuizResultDto
    {
        public int AttemptId { get; set; }

        public int? SectionId { get; set; }
        public string? SectionTitle { get; set; }

        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}
