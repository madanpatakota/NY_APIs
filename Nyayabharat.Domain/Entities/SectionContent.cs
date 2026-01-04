using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Domain.Entities
{
    public class SectionContent
    {

        [Key]
        public int ContentId { get; set; }
        public int SectionId { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string ContentText { get; set; } = string.Empty;

        public Section Section { get; set; } = null!;

        public Language Language { get; set; }
    }

}
