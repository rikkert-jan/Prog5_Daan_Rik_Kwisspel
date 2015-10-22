using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    public class DummyQuestionRepository : IQuestionRepository
    {
        private List<Question> _questions = new List<Question>
        {
            new Question
            {
                Answers = new List<Answer>{new Answer()},Category = new Category {  CategoryId = 0, CategoryName = "iets"}, QuestionId = 0, Questiontext = "mama?"
            },
            new Question
            {
                Answers = new List<Answer>{new Answer(), new Answer()},Category = new Category {  CategoryId = 1, CategoryName = "iets"}, QuestionId = 0, Questiontext = "papa?"
            },
            new Question
            {
                Answers = new List<Answer>(),Category = new Category {  CategoryId = 2, CategoryName = "bob"}, QuestionId = 0, Questiontext = "baba?"
            }
        };

        public Question Get(int id)
        {
            return _questions.First(question => question.QuestionId == id);
        }

        public List<Question> GetAll()
        {
            return _questions;
        }

        public void Create(Question question)
        {
            _questions.Add(question);
        }

        public void Delete(Question question)
        {
            _questions.Remove(question);
        }
    }
}
