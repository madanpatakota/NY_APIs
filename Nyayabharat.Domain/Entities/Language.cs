namespace Nyayabharat.Domain.Entities
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }
}
