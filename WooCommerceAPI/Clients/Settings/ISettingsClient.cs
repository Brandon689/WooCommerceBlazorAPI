using WooCommerceAPI.Models.Services.Foundations.Settings;

namespace WooCommerceAPI.Clients.Settings
{
    public interface ISettingsClient
    {
        ValueTask<Setting> GetSettings();
    }
}
