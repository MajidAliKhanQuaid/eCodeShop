using eShopCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ECodeShopContext _dbContext;
        public AuthenticationController(ECodeShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public dynamic GetValues()
        {
            return _dbContext.Users.ToList();
        }
    }
}
