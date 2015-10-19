using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    class DummyQuizRepository : IQuizRepository
    {
        private List<Quiz> _quizzes = new List<Quiz>();

        public Quiz Get(int id)
        {
            return _quizzes.First(quiz => quiz.QuizId == id);
        }

        public List<Quiz> GetAll()
        {
            return _quizzes;
        }

        public void Create(Quiz quiz)
        {
            _quizzes.Add(quiz);
        }

        public void Delete(Quiz quiz)
        {
            _quizzes.Remove(quiz);
        }
    }
}
