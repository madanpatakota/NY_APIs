using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Domain.Entities
{
    public class TranslationBulkRequest
    {
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public List<string> FieldNames { get; set; } = new();
        public string LanguageCode { get; set; } = null!;
    }
}
