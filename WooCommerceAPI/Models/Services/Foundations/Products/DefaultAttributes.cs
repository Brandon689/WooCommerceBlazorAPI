using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DefaultAttribute
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Option { get; set; }
    }
}
