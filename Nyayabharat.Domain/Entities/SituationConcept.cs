namespace Nyayabharat.Domain.Entities
{
    public class SituationConcept
    {
        public int SituationId { get; set; }
        public int ConceptId { get; set; }

        public Situation Situation { get; set; } = null!;
        public Concept Concept { get; set; } = null!;
    }
}
