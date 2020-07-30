using eCodeShop.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Dtos
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("user")]
        public virtual User User { get; set; }
        [JsonProperty("orderTotal")]
        public decimal OrderTotal { get; set; }
        [JsonProperty("createdOnUtc")]
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        [JsonProperty("updatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;
    }
}
