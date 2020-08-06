using eCodeShop.Core.Dtos;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Interfaces;
using eCodeShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class UserContoller : ControllerBase
    {
        private IRepository<User> _usersRepo;
        private IUserService _userService;

        public UserContoller(IRepository<User> usersRepo, IUserService userService)
        {
            _usersRepo = usersRepo;
            _userService = userService;
        }

        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            var response = users.Select(x => new UserDto()
            {
                Id = x.Id,
                Name = (x.FirstName ?? string.Empty + x.LastName ?? string.Empty), 
                Email = x.Email
            }).ToList();
            //
            return Ok(response);
        }
    }
}
