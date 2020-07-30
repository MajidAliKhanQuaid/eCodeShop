using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
