using eCodeShop.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Dtos
{
    public class ShoppingCartItemDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        //[JsonProperty("user")]
        //public virtual User User { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("product")]
        public virtual Product Product { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}
