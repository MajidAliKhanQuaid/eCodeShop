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
using eCodeShop.Services.Interfaces;
using eCodeShop.Core.Dtos;
using System.Threading.Tasks;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IConfiguration _configuration;
        private IProductService _productService;
        private IPictureService _pictureService;
        private IHostingEnvironment _hostingEnv;

        public ProductController(IConfiguration configuration, IProductService productService, IPictureService pictureService, IHostingEnvironment hostingEnv)
        {
            _configuration = configuration;
            _productService = productService;
            _pictureService = pictureService;
            _hostingEnv = hostingEnv;
        }

        [HttpPost("find")]
        public Product FindProduct(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost("save")]
        public IActionResult SaveProduct([FromForm] ProductDto productDto)
        {
            try
            {
                if (productDto == null) return BadRequest();
                Product product = new Product();
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Description = productDto.Description;
                bool isSaved = _productService.SaveProduct(product);
                if (isSaved)
                {
                    //
                    try
                    {
                        string directoryPath = _hostingEnv.WebRootPath + "\\uploads\\";
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        string savePath = directoryPath + productDto.Image.FileName;
                        using (FileStream filestream = System.IO.File.Create(savePath))
                        {
                            productDto.Image.CopyTo(filestream);
                            filestream.Flush();
                        }
                        //
                        Picture picture = new Picture();
                        picture.Name = productDto.Image.FileName;
                        picture.ImageUrl = "\\uploads\\" + productDto.Image.FileName;
                        //
                        isSaved = _pictureService.SavePicture(picture);
                        if (isSaved)
                        {
                            isSaved = _pictureService.AddProductPicture(product.Id, picture.Id);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                //
                return Ok(product);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            var response = products.Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ProductPictureMappings.FirstOrDefault()?.Picture?.ImageUrl,
            }).ToList();
            //
            return Ok(response);
        }

    }
}
