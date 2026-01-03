using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class SituationGuidanceRepository : ISituationGuidanceRepository
    {
        private readonly NyayabharatDbContext _context;

        public SituationGuidanceRepository(NyayabharatDbContext context)
        {
            _context = context;
        }

        public async Task<List<SituationGuidance>> GetBySituationIdAsync(int situationId)
        {
            return await _context.SituationGuidance
                .Where(g => g.SituationId == situationId)
                .OrderBy(g => g.StepOrder)
                .ToListAsync();
        }
    }
}
