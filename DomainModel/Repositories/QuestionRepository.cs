using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public Question Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Question question)
        {
            throw new NotImplementedException();
        }

        public void Delete(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
