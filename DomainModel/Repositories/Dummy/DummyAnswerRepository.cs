using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    public class DummyAnswerRepository : IAnswerRepository
    {
        private List<Answer> _answers = new List<Answer> {new Answer {AnswerId = 1, AnswerText = "42", IsCorrect = true} };

        public Answer Get(int id)
        {
            return _answers.First(answer => answer.AnswerId == id);
        }

        public List<Answer> GetAll()
        {
            return _answers;
        }

        public void Create(Answer answer)
        {
            _answers.Add(answer);
        }

        public void Delete(Answer answer)
        {
            _answers.Remove(answer);
        }
    }
}
