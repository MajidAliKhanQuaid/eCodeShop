using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPerItem { get; set; }
    }
}
