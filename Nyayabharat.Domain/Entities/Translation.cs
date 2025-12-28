using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Translation
    {


        [Key]
        public int TranslationId { get; set; }

        public string EntityType { get; set; } = string.Empty;
        public int EntityId { get; set; }

        public string FieldName { get; set; } = string.Empty;

        public bool isActive { get; set; } = true;
        public string FieldValue { get; set; }

        public int LanguageId { get; set; }
        public string TranslatedText { get; set; } = string.Empty;

        public Language Language { get; set; } = null!;
    }
}
