using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IQuizAttemptRepository : IGenericRepository<QuizAttempt>
    {
        Task AddAttemptAsync(QuizAttempt attempt);
        Task UpdateAttemptAsync(QuizAttempt attempt);
    }

}
