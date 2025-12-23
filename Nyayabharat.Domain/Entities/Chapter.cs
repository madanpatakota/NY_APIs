using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }   // MUST exist

        public int ActId { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterTitle { get; set; }
    }

}
