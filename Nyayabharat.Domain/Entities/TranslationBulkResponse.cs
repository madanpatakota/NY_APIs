using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Domain.Entities
{
    public class TranslationBulkResponse
    {
        public string FieldName { get; set; } = null!;
        public string TranslatedText { get; set; } = null!;
    }
}
