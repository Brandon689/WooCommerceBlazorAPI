using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Taxis
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }
    }
}
