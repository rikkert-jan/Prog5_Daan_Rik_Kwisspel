using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    public class DummyQuizRepository : IQuizRepository
    {
        private List<Quiz> _quizzes = new List<Quiz>
        {
            new Quiz {Questions = new List<Question> {new Question(), new Question()}, QuizId = 1, QuizName = "Quiz1" },
            new Quiz {Questions = new List<Question> {new Question()}, QuizId = 2, QuizName = "Quiz2" },
            new Quiz {Questions = new List<Question>(), QuizId = 3, QuizName = "Quiz3" }
        };

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

        public void Update(Quiz quiz)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Quiz quiz)
        {
            _quizzes.Remove(quiz);
        }
    }
}
