using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Dtos
{
    public class CategoryDto
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
