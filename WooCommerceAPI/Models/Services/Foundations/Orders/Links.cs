using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Links
    {
        [JsonProperty("self")]
        public List<Self> Self { get; set; }

        [JsonProperty("collection")]
        public List<Collection> Collection { get; set; }
    }
}
