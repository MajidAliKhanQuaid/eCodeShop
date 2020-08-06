using eCodeShop.Core.Entities;
using eCodeShop.Core.Interfaces;
using eCodeShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCodeShop.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepo.Table.ToList();
        }
    }
}
