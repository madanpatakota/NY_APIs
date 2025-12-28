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


        public async Task<Translation?> GetAsync(
    string entityType,
    int entityId,
    string fieldName,
    string languageCode)
        {
            return await (
                from t in _context.Translations
                join l in _context.Languages
                    on t.LanguageId equals l.LanguageId
                where t.EntityType == entityType
                   && t.EntityId == entityId
                   && t.FieldName == fieldName
                   && l.Code == languageCode
                   && l.IsActive
                select t
            ).FirstOrDefaultAsync();
        }


        public async Task<List<TranslationBulkResponse>> GetBulkAsync(
    string entityType,
    int entityId,
    List<string> fieldNames,
    string languageCode)
        {
            return await (
                from t in _context.Translations
                join l in _context.Languages
                    on t.LanguageId equals l.LanguageId
                where t.EntityType == entityType
                   && t.EntityId == entityId
                   && fieldNames.Contains(t.FieldName)
                   && l.Code == languageCode
                   && l.IsActive
                select new TranslationBulkResponse
                {
                    FieldName = t.FieldName,
                    TranslatedText = t.TranslatedText
                }
            ).ToListAsync();
        }


    }
}
