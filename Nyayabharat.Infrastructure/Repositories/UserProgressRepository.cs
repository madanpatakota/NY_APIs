using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class UserProgressRepository : GenericRepository<UserProgress>, IUserProgressRepository
    {
        public UserProgressRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task UpdateProgressAsync(UserProgress progress)
        {
            _context.UserProgresses.Update(progress);
            await _context.SaveChangesAsync();
        }

    }
}
