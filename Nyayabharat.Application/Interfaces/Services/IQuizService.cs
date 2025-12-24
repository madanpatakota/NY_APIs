using Nyayabharat.Application.DTOs.Quiz;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IQuizService
    {
        //Task<IEnumerable<QuizQuestionDto>> StartQuizAsync(int situationId, string difficulty);
        Task<QuizResultDto> SubmitQuizAsync(int attemptId, Dictionary<int, int> answers);

        Task<IEnumerable<QuizQuestionDto>> StartQuizAsync(
            int situationId,
            string difficulty,
            string userType);

    }
}
