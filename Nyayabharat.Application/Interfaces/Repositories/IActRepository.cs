using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IActRepository : IGenericRepository<Act>
    {
        // Get only active Acts
        Task<IEnumerable<Act>> GetActiveActsAsync();

        // Get Act by Id with Chapters + Category
        //Task<Act?> GetByIdAsync(int actId);
    }
}
