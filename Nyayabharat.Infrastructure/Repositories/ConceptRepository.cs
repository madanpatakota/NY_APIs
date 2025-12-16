using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class ConceptRepository : GenericRepository<Concept>, IConceptRepository
    {
        public ConceptRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Concept>> GetBySituationIdAsync(int situationId)
        {
            return await _context.SituationConcepts
                .Where(x => x.SituationId == situationId)
                .Select(x => x.Concept)
                .ToListAsync();
        }
    }
}
