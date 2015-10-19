using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IQuizRepository 
    {
        Quiz Get(int id);
        List<Quiz> GetAll();
        void Create(Quiz quiz);
        void Delete(Quiz quiz);
    }
}
