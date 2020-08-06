using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Dtos
{
    public class UserTokenDto
    {
        public int Expiry { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
