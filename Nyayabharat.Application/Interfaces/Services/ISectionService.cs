using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetByActIdAsync(int actId);
        Task<Section?> GetWithDetailsAsync(int sectionId);
    }
}
