using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private MyContext _context = new MyContext();

        public Question Get(int id)
        {
            return _context.Questions.First(question => question.QuestionId == id);
        }

        public List<Question> GetAll()
        {
            return _context.Questions.ToList();
        }

        public void Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            _context.SaveChanges();
        }

        public void Delete(Question question)
        {
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}
