using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IAnswerRepository : IRepository
    {
        Answer Get(int id);
        List<Answer> GetAll();
        void Create(Answer answer);
        void Delete(Answer answer);
    }
}
