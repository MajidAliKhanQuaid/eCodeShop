using eCodeShop.Core.Interfaces;
using eShopCore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Models;
using eCodeShop.Core.Dtos;
using eCodeShop.Services.Interfaces;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private IConfiguration _configuration;
        private IRepository<User> _usersRepo;

        public AuthenticationController(ITokenService tokenService, IUserService userService, IConfiguration configuration, IRepository<User> usersRepo)
        {
            _tokenService = tokenService;
            _userService = userService;
            _configuration = configuration;
            _usersRepo = usersRepo;
        }

        [HttpGet("test")]
        public dynamic GetValues()
        {
            return _usersRepo.Table.ToList();
        }

        [AllowAnonymous]
        [HttpPost(template: "token", Name = "tokenRequest")]
        public IActionResult Token([FromBody] User user)
        {
            var tokenModel = _userService.Authenticate(user.Email, user.Password);
            if (tokenModel == null)
            {
                return new ForbidResult();
            }
            return Ok(tokenModel);
        }

    }
}
