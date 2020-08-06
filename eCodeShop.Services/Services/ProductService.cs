using eCodeShop.Core.Entities;
using eCodeShop.Core.Interfaces;
using eCodeShop.Core.Models;
using eCodeShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodeShop.Services.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productsRepo;
        private IPictureService _pictureService;
        
        public ProductService(IRepository<Product> productsRepo, IPictureService pictureService)
        {
            _productsRepo = productsRepo;
            _pictureService = pictureService;
        }

        public Product GetProductById(int id)
        {
            return _productsRepo.GetById(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _productsRepo.Table.Include(x => x.ProductPictureMappings).ThenInclude(x => x.Picture).ToListAsync();
            return products;
        }

        public bool SaveProduct(Product product)
        {
            _productsRepo.Insert(product);
            return true;
        }

    }
}
