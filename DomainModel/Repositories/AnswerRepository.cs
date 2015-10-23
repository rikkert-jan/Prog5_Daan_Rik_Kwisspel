using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private MyContext _context = new MyContext();

        public Answer Get(int id)
        {
            return _context.Answers.First(answer => answer.AnswerId == id);
        }

        public List<Answer> GetAll()
        {
            return _context.Answers.ToList();
        }

        public void Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            _context.SaveChanges();
        }

        public void Delete(Answer answer)
        {
            _context.Answers.Remove(answer);
            _context.SaveChanges();
        }
    }
}
