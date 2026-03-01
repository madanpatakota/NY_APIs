using Nyayabharat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Application.DTOs.Act
{
    public class ActListDto
    {
        public int ActId { get; set; }
        public string ActName { get; set; } = string.Empty;
        public string? ActShortName { get; set; }
        public string ActType { get; set; } = string.Empty; // CategoryCode
        public string Status { get; set; } = string.Empty;

        public string CategoryName  { get; set; } = string.Empty;
    }
}
