using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            UserRoles = new List<UserRole>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string RefreshToken { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }

    }
}
