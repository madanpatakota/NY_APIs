using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IUserProgressRepository : IGenericRepository<UserProgress>
    {
        Task UpdateProgressAsync(UserProgress progress);
    }
}
