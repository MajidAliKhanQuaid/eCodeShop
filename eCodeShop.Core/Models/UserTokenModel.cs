using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Models
{
    public class UserTokenModel
    {
        public int Expiry { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
