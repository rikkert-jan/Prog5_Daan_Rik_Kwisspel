﻿using System.Collections.Generic;
using System.Linq;
using DomainModel.Interfaces;
using DomainModel.Model;

namespace DomainModel.Repositories.Dummy
{
    public class DummyCategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category> { new Category {CategoryName = "het ene" }, new Category {CategoryName = "het andere" } };

        public Category Get(string categoryName)
        {
            return categories.First(category => category.CategoryName.Equals(categoryName));
        }

        public List<Category> GetAll()
        {
            return categories;
        }
    }
}
