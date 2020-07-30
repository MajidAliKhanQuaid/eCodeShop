using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCodeShop.Core.Data;
using eCodeShop.Core.Domain;
using eCodeShop.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
        public ShoppingCartItem SaveCartItem(ShoppingCartItemModel _shoppingCartItem)
        {
            ShoppingCartItem shoppingCartItem = null;
            if (shoppingCartItem.Id > 0)
            {
                shoppingCartItem = _shoppingCartRepo.GetById(_shoppingCartItem.Id);
                if (shoppingCartItem != null)
                {
                    shoppingCartItem.Quantity = _shoppingCartItem.Quantity;
                    shoppingCartItem.UnitPrice = _shoppingCartItem.UnitPrice;
                    //
                    return shoppingCartItem;
                }
            }
            //
            shoppingCartItem = new ShoppingCartItem();
            shoppingCartItem.ProductId = _shoppingCartItem.ProductId;
            shoppingCartItem.Quantity = _shoppingCartItem.Quantity;
            shoppingCartItem.UnitPrice = _shoppingCartItem.UnitPrice;
            //
            _shoppingCartRepo.Insert(shoppingCartItem);
            //
            return shoppingCartItem;
        }
    }
}
