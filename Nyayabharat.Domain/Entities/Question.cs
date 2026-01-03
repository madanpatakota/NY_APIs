using Nyayabharat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nyayabharat.Domain.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        // =========================
        // QUIZ CONTEXT
        // =========================

        // Situation-based quiz (PRIMARY)
        public int SituationId { get; set; }

        // Section-based quiz (OPTIONAL / FUTURE SAFE)
        public int? SectionId { get; set; }

        // =========================
        // QUESTION DATA
        // =========================

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public QuestionType QuestionType { get; set; }

        [Required]
        public string Difficulty { get; set; } = string.Empty;
        // easy | medium | hard

        // Who can attempt (Citizen / Advocate / Admin)
        public UserType AllowedUserType { get; set; }

        // =========================
        // NAVIGATION
        // =========================

        public ICollection<Option> Options { get; set; } = new List<Option>();

        // Optional explanation (can be multilingual later)
        public Explanation? Explanation { get; set; }

        // =========================
        // AUDIT (OPTIONAL)
        // =========================
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
