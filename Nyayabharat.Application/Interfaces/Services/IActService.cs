using Nyayabharat.Application.DTOs.Act;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IActService
    {
        Task<List<ActListDto>> GetAllActsAsync();
        Task<List<ActListDto>> GetActiveActsAsync();
        Task<ActDto?> GetByIdAsync(int actId);
    }
}
