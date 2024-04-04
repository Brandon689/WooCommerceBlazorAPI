using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Collection
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
