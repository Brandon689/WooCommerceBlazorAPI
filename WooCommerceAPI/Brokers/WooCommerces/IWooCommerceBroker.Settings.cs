using WooCommerceAPI.Models.Services.Foundations.Settings;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<Setting> GetSettings();
    }
}
