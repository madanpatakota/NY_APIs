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
        try
        {
            await _dbSet.AddAsync(attempt);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Log the exception (you can use any logging framework)
            Console.WriteLine($"Error adding quiz attempt: {ex.Message}");
            throw; // Re-throw the exception after logging it
        }
    }

    public async Task UpdateAttemptAsync(QuizAttempt attempt)
    {
        try {
            _dbSet.Update(attempt);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Log the exception (you can use any logging framework)
            Console.WriteLine($"Error updating quiz attempt: {ex.Message}");
            throw; // Re-throw the exception after logging it
        }
       
    }
}
