using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class ActRepository : GenericRepository<Act>, IActRepository
    {
        public ActRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Act>> GetActiveActsAsync()
        {
            return await _context.Acts
                .Where(a => a.Status == "Active")
                .ToListAsync();
        }
    }
}
