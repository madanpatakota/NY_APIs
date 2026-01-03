using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;
using Nyayabharat.Infrastructure.Repositories;

public class QuizAttemptRepository
    : GenericRepository<QuizAttempt>, IQuizAttemptRepository
{
    public QuizAttemptRepository(NyayabharatDbContext context)
        : base(context) { }

    public async Task AddAttemptAsync(QuizAttempt attempt)
    {
        await _dbSet.AddAsync(attempt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAttemptAsync(QuizAttempt attempt)
    {
        _dbSet.Update(attempt);
        await _context.SaveChangesAsync();
    }
}
