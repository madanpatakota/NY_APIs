namespace Nyayabharat.Domain.Entities
{
    public class Translation
    {
        public int TranslationId { get; set; }

        public string EntityType { get; set; } = string.Empty;
        public int EntityId { get; set; }

        public int LanguageId { get; set; }
        public string TranslatedText { get; set; } = string.Empty;

        public Language Language { get; set; } = null!;
    }
}
