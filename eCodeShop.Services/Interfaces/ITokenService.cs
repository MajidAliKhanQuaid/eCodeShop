using eCodeShop.Core.Dtos;
using eCodeShop.Core.Entities;
using eCodeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Services.Interfaces
{
    public interface ITokenService
    {
        UserTokenDto GenerateToken(User user);
    }
}
