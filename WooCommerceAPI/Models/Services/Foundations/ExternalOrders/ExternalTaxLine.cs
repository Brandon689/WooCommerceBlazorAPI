using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Orders
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    internal class ExternalTaxLine
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("rate_code")]
        public string? RateCode { get; set; }

        [JsonProperty("rate_id")]
        public int? RateId { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("compound")]
        public bool? Compound { get; set; }

        [JsonProperty("tax_total")]
        public string? TaxTotal { get; set; }

        [JsonProperty("shipping_tax_total")]
        public string? ShippingTaxTotal { get; set; }

        [JsonProperty("meta_data")]
        public List<object>? MetaData { get; set; }
    }
}
