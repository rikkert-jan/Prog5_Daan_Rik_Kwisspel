using System.Collections.Generic;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IAnswerRepository 
    {
        Answer Get(int id);
        List<Answer> GetAll();
        void Create(Answer answer);
        void Delete(Answer answer);
    }
}
