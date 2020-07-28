using eCodeShop.Core.Data;
using eCodeShop.Core.Domain;
using eCodeShop.Core.Dtos;
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
using System.Text;

namespace eCodeShop.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRepository<User> _usersRepo;
        
        public AuthenticationController(IConfiguration configuration, IRepository<User> usersRepo)
        {
            _configuration = configuration;
            _usersRepo = usersRepo;
        }

        // testing method
        public dynamic GetValues()
        {
            return _usersRepo.Table.ToList();
        }

        [AllowAnonymous]
        [HttpPost(template: "token", Name = "tokenRequest")]
        public UserTokenModel Token(UserModel user)
        {
            var jwtConfig = _configuration.GetSection("jwt");
            
            string secretKey = jwtConfig.GetValue<string>("SecretKey");
            string issuerName = jwtConfig.GetValue<string>("IssuerName");

            // Validate User Here i.e.
            var vUser = _usersRepo.Table.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (vUser == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuerName,
              null,
              null,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserTokenModel() { Email = user.Email, Token = jwtToken, Expiry = 5 };
        }

    }
}
