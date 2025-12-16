namespace Nyayabharat.Domain.Entities
{
    public class UserProgress
    {
        public int UserProgressId { get; set; }
        public int UserId { get; set; }
        public int? ConceptId { get; set; }
        public int? SectionId { get; set; }
        public int MasteryLevel { get; set; }
        public DateTime? LastAttemptedOn { get; set; }
    }
}
