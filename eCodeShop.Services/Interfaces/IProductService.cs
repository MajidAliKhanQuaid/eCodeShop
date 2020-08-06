using eCodeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCodeShop.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int id);
        Task<List<Product>> GetProducts();
        bool SaveProduct(Product product);
    }
}
