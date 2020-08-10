using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace eCodeShop.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductPictureMappings = new List<ProductPictureMapping>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string ImageUrl { get; set; }
        public bool Deleted { get; set; }
        [JsonIgnore]
        public virtual List<ProductPictureMapping> ProductPictureMappings { get; set; }
    }
}
