using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories
{
    public class QuizRepository : IQuizRepository
    { 
        private MyContext context = new MyContext();

        public Quiz Get(int id)
        {
            return context.Quizzes.First(quiz => quiz.QuizId == id);
        }

        public List<Quiz> GetAll()
        {
            return context.Quizzes.ToList();
        }

        public void Create(Quiz quiz)
        {
            context.Quizzes.Add(quiz);
            context.SaveChanges();
        }

        public void Update(Quiz quiz)
        {
            context.SaveChanges();
        }

        public void Delete(Quiz quiz)
        {
            context.Quizzes.Remove(quiz);
            context.SaveChanges();
        }
    }
}
