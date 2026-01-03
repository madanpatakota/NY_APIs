using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IQuizAttemptAnswerRepository
    : IGenericRepository<QuizAttemptAnswer>
    {
        Task AddAnswersAsync(List<QuizAttemptAnswer> answers);
    }

}
