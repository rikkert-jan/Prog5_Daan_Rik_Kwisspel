using System.Collections.Generic;
using DomainModel.Model;

namespace DomainModel.Interfaces
{
    public interface ICategoryRepository 
    {
        Category Get(string categoryName);
        List<Category> GetAll();
    }
}
