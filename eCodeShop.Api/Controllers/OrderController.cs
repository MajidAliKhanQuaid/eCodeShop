using eCodeShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using eCodeShop.Core.Entities;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRepository<Order> _ordersRepo;

        public OrderController(IConfiguration configuration, IRepository<Order> ordersRepo)
        {
            _configuration = configuration;
            _ordersRepo = ordersRepo;
        }

        [HttpPost("placeOrder")]
        public Order SaveOrder(Order order)
        {
            _ordersRepo.Insert(order);
            return null;
        }
    }
}
