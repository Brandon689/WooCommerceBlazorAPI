using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSettings
    {
        [JsonProperty("api_enabled")]
        public bool? ApiEnabled { get; set; }

        [JsonProperty("force_ssl")]
        public bool? ForceSsl { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currency_position")]
        public string CurrencyPosition { get; set; }

        [JsonProperty("thousand_separator")]
        public string ThousandSeparator { get; set; }

        [JsonProperty("decimal_separator")]
        public string DecimalSeparator { get; set; }

        [JsonProperty("number_of_decimals")]
        public int? NumberOfDecimals { get; set; }

        [JsonProperty("geolocation_enabled")]
        public bool? GeolocationEnabled { get; set; }

        [JsonProperty("taxonomies")]
        public ExternalTaxonomies Taxonomies { get; set; }
    }
}
