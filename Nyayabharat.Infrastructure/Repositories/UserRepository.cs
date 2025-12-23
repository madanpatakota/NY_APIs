using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NyayabharatDbContext _context;

        public UserRepository(NyayabharatDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
