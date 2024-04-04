using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Slug { get; set; }
    }
}
