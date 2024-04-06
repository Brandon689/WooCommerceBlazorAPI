using WooCommerceAPI.Models.Services.Foundations.Settings;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string SettingsRelativeUrl = "/wp-json/wc/v3/settings";

        public async ValueTask<Setting> GetSettings()
        {
            return await GetAsync<Setting>(relativeUrl: $"{SettingsRelativeUrl}");
        }
    }
}
