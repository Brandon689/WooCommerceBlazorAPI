using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ProductTags
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}
