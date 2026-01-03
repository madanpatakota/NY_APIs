using Nyayabharat.Application.DTOs.Quiz;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizQuestionDto>> StartSituationQuizAsync(
            int situationId,
            string difficulty,
            string userType
        );

        Task<IEnumerable<QuizQuestionDto>> StartSectionQuizAsync(
            int sectionId,
            string difficulty,
            string userType
        );

        Task<QuizResultDto> SubmitQuizAsync(
            int attemptId,
            Dictionary<int, int> answers
        );







    }
}
