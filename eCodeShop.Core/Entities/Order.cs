using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
