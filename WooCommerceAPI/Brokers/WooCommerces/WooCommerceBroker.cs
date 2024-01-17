using RESTFulSense.Clients;
using System.Net.Http.Headers;
using System.Text;
using WooCommerceAPI.Models.Configurations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker : IWooCommerceBroker
    {
        private readonly WooCommerceConfigurations wooCommerceConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;

        public WooCommerceBroker(WooCommerceConfigurations wooCommerceConfigurations)
        {
            this.wooCommerceConfigurations = wooCommerceConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.apiClient.GetContentAsync<T>(relativeUrl);

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content);

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            return await this.apiClient.PostContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        }

        private async ValueTask<TResult> PostFormAsync<TRequest, TResult>(string relativeUrl, TRequest content)
            where TRequest : class
        {
            return await this.apiClient.PostFormAsync<TRequest, TResult>(
                relativeUrl,
                content);
        }

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PutContentAsync<T>(relativeUrl, content, "application/json");

        private async ValueTask<TResult> PutAsync<TRequest, TResult>(string relativeUrl, TRequest content) =>
            await this.apiClient.PutContentAsync<TRequest, TResult>(relativeUrl, content, "application/json");

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<T>(relativeUrl);

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uriString: this.wooCommerceConfigurations.ApiUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Basic",
                    parameter: Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.wooCommerceConfigurations.ApiKey}:{this.wooCommerceConfigurations.ApiSecret}")));

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);
    }
}
