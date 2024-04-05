using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalCustomers
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    internal class ExternalCustomer
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("date_created_gmt")]
        public DateTime? DateCreatedGmt { get; set; }

        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("date_modified_gmt")]
        public DateTime? DateModifiedGmt { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("billing")]
        public ExternalBilling? Billing { get; set; }

        [JsonProperty("shipping")]
        public ExternalShipping? Shipping { get; set; }

        [JsonProperty("is_paying_customer")]
        public bool? IsPayingCustomer { get; set; }

        [JsonProperty("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonProperty("meta_data")]
        public List<ExternalProductMetadata>? MetaData { get; set; }

        [JsonProperty("_links")]
        public ExternalLinks? Links { get; set; }
    }
}
