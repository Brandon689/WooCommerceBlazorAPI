using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalMedia
{
    internal class ExternalMediaItemResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("src")]
        public string Src { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("alt")]
        public string Alt { get; set; } = string.Empty;
    }
}
