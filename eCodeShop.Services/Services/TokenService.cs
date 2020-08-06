using eCodeShop.Core.Dtos;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Models;
using eCodeShop.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCodeShop.Services.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserTokenDto GenerateToken(User user)
        {
            UserTokenDto userToken = new UserTokenDto();
            //
            var tokenHandler = new JwtSecurityTokenHandler();
            //
            var jwtConfig = _configuration.GetSection("jwt");
            string secretKey = jwtConfig.GetValue<string>("SecretKey");
            string issuerName = jwtConfig.GetValue<string>("IssuerName");
            int tokenValidity = jwtConfig.GetValue<int>("Validity");
            //
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            
            foreach(var userRole in user.UserRoles)
            {
                if(userRole.Role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                }
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuerName,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(tokenValidity),
                SigningCredentials = credentials
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            //
            userToken.Email = user.Email;
            userToken.AccessToken = token;
            userToken.Expiry = tokenValidity;
            //
            return userToken;
        }
    }
}
