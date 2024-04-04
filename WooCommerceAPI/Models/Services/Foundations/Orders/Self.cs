using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    public class Self
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
