using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    internal class ExternalProductAttribute
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("position")]
        public int Position { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; } = true;

        [JsonProperty("variation")]
        public bool Variation { get; set; }

        [JsonProperty("options")]
        public string[] Options { get; set; }
    }
}
