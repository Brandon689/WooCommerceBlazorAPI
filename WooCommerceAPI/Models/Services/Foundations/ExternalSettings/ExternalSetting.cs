using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSettings
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSetting
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        [JsonProperty("sub_groups")]
        public string[]? SubGroups { get; set; }

        //[JsonProperty("_links")]
        //public Links Links { get; set; }
    }
}
