using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class ProductPictureMapping : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public bool IsDefault { get; set; }
    }
}
