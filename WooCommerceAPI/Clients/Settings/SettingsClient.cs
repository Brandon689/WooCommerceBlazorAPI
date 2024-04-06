using WooCommerceAPI.Models.Services.Foundations.Settings;
using WooCommerceAPI.Services.Foundations.Settings;

namespace WooCommerceAPI.Clients.Settings
{
    internal partial class SettingsClient : ISettingsClient
    {
        private readonly ISettingsService settingsService;

        public SettingsClient(ISettingsService settingsService) =>
            this.settingsService = settingsService;

        public async ValueTask<Setting> GetSettings()
        {
            return await settingsService.GetSettings();
        }
    }
}
