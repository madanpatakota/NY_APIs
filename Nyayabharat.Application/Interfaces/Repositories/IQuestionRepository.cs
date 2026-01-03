using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuizQuestionsBySituationAsync(
            int situationId,
            string difficulty,
            UserType userType
        );

        Task<IEnumerable<Question>> GetQuizQuestionsBySectionAsync(
            int sectionId,
            string difficulty,
            UserType userType
        );

        // 🔥 ADD THIS (recommended)
        Task<Question?> GetQuestionWithOptionsAsync(int questionId);




    }
}
