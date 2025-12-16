using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class SituationRepository : GenericRepository<Situation>, ISituationRepository
    {
        public SituationRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Situation>> GetBySeverityAsync(SeverityLevel severity)
        {
            return await _context.Situations
                .Where(s => s.Severity == severity)
                .ToListAsync();
        }
    }
}
