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
        private List<Category> _categories = new List<Category>();

        public Category Get(int id)
        {
            return _categories.First(category => category.CategoryId == id);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }
    }
}
