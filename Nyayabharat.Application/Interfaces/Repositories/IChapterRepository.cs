using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface IChapterRepository
    {
        Task<List<Chapter>> GetByActIdAsync(int actId);
    }
}
