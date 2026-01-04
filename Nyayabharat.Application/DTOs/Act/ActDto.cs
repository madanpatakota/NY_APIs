using Nyayabharat.Application.DTOs.Chapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Application.DTOs.Act
{
    public class ActDto
    {
        public int ActId { get; set; }
        public string ActName { get; set; } = string.Empty;
        public string? ActShortName { get; set; }

        public int EnactedYear { get; set; }
        public string? Authority { get; set; }
        public string Status { get; set; } = string.Empty;

        // Act classification (optional but recommended)
        public string ActType { get; set; } = string.Empty;

        // Chapters under this Act
        public List<ChapterDto> Chapters { get; set; } = new();
    }
}
