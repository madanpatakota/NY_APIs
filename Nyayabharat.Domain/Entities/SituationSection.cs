using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{

    public class SituationSection
    {
        public int SituationId { get; set; }
        public Situation Situation { get; set; } = null!;

        public int SectionNumber { get; set; }
        public Section Section { get; set; } = null!;
    }
    //public class SituationSection
    //{


    //    [Key]
    //    public int SituationId { get; set; }
    //    public int SectionId { get; set; }

    //    public Situation Situation { get; set; } = null!;
    //    public Section Section { get; set; } = null!;

    //    public Act Act { get; set; } = null!;
    //}

}
