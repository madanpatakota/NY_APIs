namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<string?> GetTranslatedTextAsync(
            string entityType,
            int entityId,
            string languageCode);
    }
}
