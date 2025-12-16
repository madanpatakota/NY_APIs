using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class TranslationRepository : GenericRepository<Translation>, ITranslationRepository
    {
        public TranslationRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<Translation?> GetAsync(string entityType, int entityId, string languageCode)
        {
            return await _context.Translations
                .Include(t => t.Language)
                .Where(t =>
                    t.EntityType == entityType &&
                    t.EntityId == entityId &&
                    t.Language.Code == languageCode)
                .FirstOrDefaultAsync();
        }
    }
}
