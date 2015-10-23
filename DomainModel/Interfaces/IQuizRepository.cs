using System.Collections.Generic;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IQuizRepository 
    {
        Quiz Get(int id);
        List<Quiz> GetAll();
        void Create(Quiz quiz);
        void Update(Quiz quiz);
        void Delete(Quiz quiz);
    }
}
