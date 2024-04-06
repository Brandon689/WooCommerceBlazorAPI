using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSecurity
    {
        [JsonProperty("secure_connection")]
        public bool? SecureConnection { get; set; }

        [JsonProperty("hide_errors")]
        public bool? HideErrors { get; set; }
    }
}
