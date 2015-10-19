using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    class DummyQuestionRepository : IQuestionRepository
    {
        private List<Question> _questions = new List<Question>();

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
