using WooCommerceAPI.Models.Services.Foundations.Settings;

namespace WooCommerceAPI.Services.Foundations.Settings
{
    internal interface ISettingsService
    {
        ValueTask<Setting> GetSettings();
    }
}
