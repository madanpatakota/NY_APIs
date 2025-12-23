using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Question>> GetQuestionsBySituationIdAsync(int situationId)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.SituationId == situationId)
                .ToListAsync();
        }

        // ✅ NEW – quiz-specific, user-type based
        public async Task<IEnumerable<Question>> GetQuizQuestionsAsync(
            int situationId,
            string difficulty,
            UserType userType)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Where(q =>
                    q.SituationId == situationId &&
                    q.Difficulty == difficulty &&
                    q.AllowedUserType <= userType
                )
                .ToListAsync();
        }
    }
}
