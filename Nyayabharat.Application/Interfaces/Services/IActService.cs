using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IActService
    {
        Task<IEnumerable<Act>> GetAllAsync();
        Task<IEnumerable<Act>> GetActiveAsync();
        Task<Act?> GetByIdAsync(int actId);
    }
}
