using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalDatabase
    {
        [JsonProperty("wc_database_version")]
        public string? WcDatabaseVersion { get; set; }

        [JsonProperty("database_prefix")]
        public string? DatabasePrefix { get; set; }

        [JsonProperty("maxmind_geoip_database")]
        public string? MaxmindGeoipDatabase { get; set; }

        [JsonProperty("database_tables")]
        public ExternalDatabaseTables? DatabaseTables { get; set; }
    }
}
