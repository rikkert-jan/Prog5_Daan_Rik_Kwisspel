using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface ICategoryRepository 
    {
        Category Get(int id);
        List<Category> GetAll();
    }
}
