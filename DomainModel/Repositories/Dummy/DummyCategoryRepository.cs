using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    public class DummyCategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category> { new Category { CategoryId = 0, CategoryName = "het ene" }, new Category { CategoryId = 1, CategoryName = "het andere" } };

        public Category Get(int id)
        {
            return categories.First(category => category.CategoryId == id);
        }

        public List<Category> GetAll()
        {
            return categories;
        }
    }
}
