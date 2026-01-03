using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly NyayabharatDbContext _context;

        public QuestionRepository(NyayabharatDbContext context)
        {
            _context = context;
        }

        // ================================
        // SITUATION-BASED QUIZ
        // ================================
        public async Task<IEnumerable<Question>> GetQuizQuestionsBySituationAsync(
            int situationId,
            string difficulty,
            UserType userType)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Where(q =>
                    q.SituationId == situationId &&
                    q.Difficulty == difficulty &&
                    q.AllowedUserType == userType
                )
                .ToListAsync();
        }

        // ================================
        // SECTION-BASED QUIZ (via SituationSectionMap)
        // ================================
        public async Task<IEnumerable<Question>> GetQuizQuestionsBySectionAsync(
            int sectionId,
            string difficulty,
            UserType userType)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Where(q =>
                    _context.SituationSections   // ✅ FIX IS HERE
                        .Any(ss =>
                            ss.SectionId == sectionId &&
                            ss.SituationId == q.SituationId
                        ) &&
                    q.Difficulty == difficulty &&
                    q.AllowedUserType == userType
                )
                .ToListAsync();
        }


        public async Task<Question?> GetQuestionWithOptionsAsync(int questionId)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);
        }
    }
}
