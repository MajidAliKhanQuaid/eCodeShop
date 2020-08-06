using eCodeShop.Core.Entities;
using eCodeShop.Core.Interfaces;
using eCodeShop.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using eCodeShop.Core.Models;
using eCodeShop.Core.Dtos;
using Microsoft.EntityFrameworkCore;

namespace eCodeShop.Services.Services
{
    public class UserService : IUserService
    {
        private ITokenService _tokenService;
        private IRepository<User> _usersRepo;

        public UserService(ITokenService tokenService ,IRepository<User> usersRepo)
        {
            _tokenService = tokenService;
            _usersRepo = usersRepo;
        }

        public UserTokenDto Authenticate(string email, string password)
        {
            var user =_usersRepo.Table
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefault();
            if(user != null)
            {
                return _tokenService.GenerateToken(user);
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            return _usersRepo.Table.Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(x => x.Email == email).FirstOrDefault();
        }


        public List<User> GetUsers()
        {
            return _usersRepo.Table.Include(x => x.UserRoles).ThenInclude(x => x.Role).ToList();
        }

    }
}
