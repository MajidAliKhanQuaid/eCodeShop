using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCodeShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Models;
using eCodeShop.Core.Dtos;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRepository<ShoppingCartItem> _shoppingCartRepo;

        public ShoppingCartController(IConfiguration configuration, IRepository<ShoppingCartItem> shoppingCartRepo)
        {
            _configuration = configuration;
            _shoppingCartRepo = shoppingCartRepo;
        }

        [HttpGet("cartitems")]
        public IActionResult GetCartItems()
        {
            var idClaim = HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault();
            if (idClaim == null)
            {
                return BadRequest(new { message = "Id not found" });
            }
            //
            int id = int.Parse(idClaim.Value);
            return Ok(_shoppingCartRepo.Table.Where(x => x.Id == id).ToList());
        }


        [HttpPost("addToCart")]
        public ShoppingCartItem SaveCartItem([FromBody] ShoppingCartItemDto sCartItemDto)
        {
            ShoppingCartItem shoppingCartItem = null;
            if (shoppingCartItem.Id > 0)
            {
                shoppingCartItem = _shoppingCartRepo.GetById(sCartItemDto.Id);
                if (shoppingCartItem != null)
                {
                    shoppingCartItem.Quantity = sCartItemDto.Quantity;
                    shoppingCartItem.UnitPrice = sCartItemDto.UnitPrice;
                    //
                    return shoppingCartItem;
                }
            }
            //
            shoppingCartItem = new ShoppingCartItem();
            shoppingCartItem.ProductId = sCartItemDto.ProductId;
            shoppingCartItem.Quantity = sCartItemDto.Quantity;
            shoppingCartItem.UnitPrice = sCartItemDto.UnitPrice;
            //
            _shoppingCartRepo.Insert(shoppingCartItem);
            //
            return shoppingCartItem;
        }
    }
}
