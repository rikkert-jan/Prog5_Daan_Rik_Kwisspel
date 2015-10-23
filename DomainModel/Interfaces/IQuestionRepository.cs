using System.Collections.Generic;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IQuestionRepository 
    {
        Question Get(int id);
        List<Question> GetAll();
        void Create(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
