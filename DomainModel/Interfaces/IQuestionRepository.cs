using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface IQuestionRepository 
    {
        Question Get(int id);
        List<Question> GetAll();
        void Create(Question question);
        void Delete(Question question);
    }
}
