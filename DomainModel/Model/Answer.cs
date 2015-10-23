using System.ComponentModel.DataAnnotations;

namespace DomainModel.Model
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}
