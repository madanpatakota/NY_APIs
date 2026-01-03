using Nyayabharat.Application.DTOs.Quiz;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IQuizService
    {
        // ================================
        // START QUIZ (WITH ACT BADGE)
        // ================================

        Task<QuizStartResponseDto> StartSituationQuizAsync(
            int situationId,
            string difficulty,
            string userType
        );

        Task<QuizStartResponseDto> StartSectionQuizAsync(
            int sectionId,
            string difficulty,
            string userType
        );

        // ================================
        // SUBMIT QUIZ
        // ================================

        Task<QuizResultDto> SubmitQuizAsync(
            int attemptId,
            Dictionary<int, int> answers
        );
    }
}
