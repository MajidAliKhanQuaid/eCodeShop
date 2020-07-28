using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eCodeShop.Core.Dtos
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("createdOnUtc")]
        public DateTime CreatedOnUtc { get; set; }
        [JsonProperty("updatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }
    }
}
