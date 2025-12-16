using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
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
    }
}
