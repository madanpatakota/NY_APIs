using Nyayabharat.Application.DTOs.Quiz;

public class QuizStartResponseDto
{
    public int AttemptId { get; set; }

    public int? ActId { get; set; }
    public string? ActShortName { get; set; }
    public string? ActName { get; set; }

    public IEnumerable<QuizQuestionDto> Questions { get; set; } = [];
}
