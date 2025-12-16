namespace Nyayabharat.Domain.Entities
{
    public class SituationSection
    {
        public int SituationId { get; set; }
        public int SectionId { get; set; }

        public Situation Situation { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}
