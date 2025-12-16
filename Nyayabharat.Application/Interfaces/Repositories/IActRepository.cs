using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IActRepository : IGenericRepository<Act>
    {
        Task<IEnumerable<Act>> GetActiveActsAsync();
    }
}
