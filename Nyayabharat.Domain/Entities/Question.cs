using Nyayabharat.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class Question
    {


        [Key]
        public int QuestionId { get; set; }
        public int SituationId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public string Difficulty { get; set; } = string.Empty;

        public ICollection<Option> Options { get; set; } = new List<Option>();
        public UserType AllowedUserType { get; set; }   // 👈 key line

    }
}
