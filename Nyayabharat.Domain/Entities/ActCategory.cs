using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Domain.Entities
{
    [Table("ActCategories")]
    public class ActCategory
    {
        public int ActCategoryId { get; set; }
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Act> Acts { get; set; } = new List<Act>();
    }
}

