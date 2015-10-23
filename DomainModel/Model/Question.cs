using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Model
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string Questiontext { get; set; }

        public Category Category { get; set; }

        [MaxLength(4)]
        public List<Answer> Answers { get; set; }
    }
}
