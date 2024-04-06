using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalDatabaseTables
    {
        [JsonProperty("woocommerce_sessions")]
        public bool? WoocommerceSessions { get; set; }

        [JsonProperty("woocommerce_api_keys")]
        public bool? WoocommerceApiKeys { get; set; }

        [JsonProperty("woocommerce_attribute_taxonomies")]
        public bool? WoocommerceAttributeTaxonomies { get; set; }

        [JsonProperty("woocommerce_downloadable_product_permissions")]
        public bool? WoocommerceDownloadableProductPermissions { get; set; }

        [JsonProperty("woocommerce_order_items")]
        public bool? WoocommerceOrderItems { get; set; }

        [JsonProperty("woocommerce_order_itemmeta")]
        public bool? WoocommerceOrderItemmeta { get; set; }

        [JsonProperty("woocommerce_tax_rates")]
        public bool? WoocommerceTaxRates { get; set; }

        [JsonProperty("woocommerce_tax_rate_locations")]
        public bool? WoocommerceTaxRateLocations { get; set; }

        [JsonProperty("woocommerce_shipping_zones")]
        public bool? WoocommerceShippingZones { get; set; }

        [JsonProperty("woocommerce_shipping_zone_locations")]
        public bool? WoocommerceShippingZoneLocations { get; set; }

        [JsonProperty("woocommerce_shipping_zone_methods")]
        public bool? WoocommerceShippingZoneMethods { get; set; }

        [JsonProperty("woocommerce_payment_tokens")]
        public bool? WoocommercePaymentTokens { get; set; }

        [JsonProperty("woocommerce_payment_tokenmeta")]
        public bool? WoocommercePaymentTokenmeta { get; set; }
    }
}
