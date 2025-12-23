using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Clause
    {
        [Key]
        public int ClauseId { get; set; }   // PRIMARY KEY

        public int SubSectionId { get; set; }
        public string ClauseLabel { get; set; }
        public string ClauseText { get; set; }
    }
}
