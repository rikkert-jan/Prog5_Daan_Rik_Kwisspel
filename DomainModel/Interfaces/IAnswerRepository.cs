using System.Collections.Generic;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IAnswerRepository 
    {
        Answer Get(int id);
        List<Answer> GetAll();
        void Create(Answer answer);
        void Update(Question question);
        void Delete(Answer answer);
    }
}
