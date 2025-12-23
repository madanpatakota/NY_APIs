using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task AddAsync(User user);
    }
}
