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

        [HttpGet("test")]
        public dynamic GetValues()
        {
            return _usersRepo.Table.ToList();
        }

        [AllowAnonymous]
        [HttpPost(template: "token", Name = "tokenRequest")]
        public UserTokenModel Token([FromBody] User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtConfig = _configuration.GetSection("jwt");

            string secretKey = jwtConfig.GetValue<string>("SecretKey");
            string issuerName = jwtConfig.GetValue<string>("IssuerName");
            int tokenValidity = jwtConfig.GetValue<int>("Validity");

            // Validate User Here i.e.
            var vUser = _usersRepo.Table.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (vUser == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", vUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, vUser.Email));
            claims.Add(new Claim(ClaimTypes.Name, vUser.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, vUser.Email));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuerName,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(tokenValidity),
                SigningCredentials = credentials
            };

            Console.Write("############ - Request for Token");
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return new UserTokenModel() { Email = user.Email, AccessToken = token, Expiry = tokenValidity };
        }

    }
}
