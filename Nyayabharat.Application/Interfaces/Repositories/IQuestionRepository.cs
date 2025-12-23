using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsBySituationIdAsync(int situationId);


        Task<IEnumerable<Question>> GetQuizQuestionsAsync(
            int situationId,
            string difficulty,
            UserType userType);
    }
}
