using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
