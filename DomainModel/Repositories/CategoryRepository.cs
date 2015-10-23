using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyContext _context = new MyContext();

        public Category Get(string categoryName)
        {
            return _context.Categories.First(categogry => categogry.CategoryName.Equals(categoryName));
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
