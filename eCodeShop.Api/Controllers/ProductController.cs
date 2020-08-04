using eCodeShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Models;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRepository<Product> _productsRepo;
        private IHostingEnvironment _hostingEnv;

        public ProductController(IConfiguration configuration, IRepository<Product> productsRepo, IHostingEnvironment hostingEnv)
        {
            _configuration = configuration;
            _productsRepo = productsRepo;
            _hostingEnv = hostingEnv;
        }

        [HttpPost("find")]
        public Product FindProduct(int id)
        {
            return _productsRepo.GetById(id);
        }

        [HttpPost("save")]
        public Product SaveProduct([FromForm] ProductModel productModel)
        {
            Product product = null;
            if (productModel.Id > 0)
            {
                product = _productsRepo.GetById(productModel.Id);
                if (product != null)
                {
                    product.Name = productModel.Name;
                    product.Price = productModel.Price;
                    product.ImageUrl = productModel.ImageUrl;
                    product.Description = productModel.Description;
                    try
                    {
                        if (!Directory.Exists(_hostingEnv.WebRootPath + "\\uploads\\"))
                        {
                            Directory.CreateDirectory(_hostingEnv.WebRootPath + "\\uploads\\");
                        }
                        string savePath = _hostingEnv.WebRootPath + "\\uploads\\" + productModel.Image.FileName;
                        using (FileStream filestream = System.IO.File.Create(savePath))
                        {
                            productModel.Image.CopyTo(filestream);
                            filestream.Flush();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    //
                    _productsRepo.Update(product);
                    //
                    return product;
                }
            }
            //
            product = new Product();
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.ImageUrl = productModel.ImageUrl;
            product.Description = productModel.Description;
            //
            try
            {
                if (!Directory.Exists(_hostingEnv.ContentRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(_hostingEnv.ContentRootPath + "\\uploads\\");
                }
                string savePath = _hostingEnv.ContentRootPath + "\\uploads\\" + productModel.Image.FileName;
                using (FileStream filestream = System.IO.File.Create(savePath))
                {
                    productModel.Image.CopyTo(filestream);
                    filestream.Flush();
                }
            }
            catch (Exception ex)
            {

            }
            //
            _productsRepo.Insert(product);
            //
            return product;
        }

        [HttpGet("all")]
        public List<ProductModel> GetProducts()
        {
            return _productsRepo.Table.Select(x => new ProductModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }

    }
}
