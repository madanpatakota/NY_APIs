using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class QuizAttemptAnswerRepository
    : GenericRepository<QuizAttemptAnswer>, IQuizAttemptAnswerRepository
    {
        public QuizAttemptAnswerRepository(NyayabharatDbContext context)
            : base(context) { }

        public async Task AddAnswersAsync(List<QuizAttemptAnswer> answers)
        {
            await _dbSet.AddRangeAsync(answers);
            await _context.SaveChangesAsync();
        }
    }

}
