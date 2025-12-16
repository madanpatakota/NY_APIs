namespace Nyayabharat.Application.DTOs.Quiz
{
    public class QuizQuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<QuizOptionDto> Options { get; set; } = new();
    }
}
