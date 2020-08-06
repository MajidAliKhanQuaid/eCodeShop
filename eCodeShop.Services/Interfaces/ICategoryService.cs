using eCodeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}
