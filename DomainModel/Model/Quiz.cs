using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Model
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public string QuizName { get; set; }

        [MinLength(2), MaxLength(10)]
        public List<Question>  Questions { get; set; }
    }
}
