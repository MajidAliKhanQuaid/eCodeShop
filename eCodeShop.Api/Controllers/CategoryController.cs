using eCodeShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eCodeShop.Core.Dtos;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public IActionResult GetCategories()
        {
            var categories =  _categoryService.GetCategories();
            var response = categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Deleted = x.Deleted
            }).ToList();
            //
            return Ok(response);
        }
    }
}
