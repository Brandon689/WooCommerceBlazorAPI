using RESTFulSense.Clients;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using WooCommerceAPI.Models.Configurations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker : IWooCommerceBroker
    {
        private readonly WooCommerceConfigurations wooCommerceConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;
        private bool OAuth;

        public WooCommerceBroker(WooCommerceConfigurations wooCommerceConfigurations, bool oAuth)
        {
            this.wooCommerceConfigurations = wooCommerceConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
            OAuth = oAuth;
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl)
        {
            OAuthCheck(HttpMethod.Get, relativeUrl);
            return await this.apiClient.GetContentAsync<T>(relativeUrl);
        }

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content)
        {
            OAuthCheck(HttpMethod.Post, relativeUrl);
            return await this.apiClient.PostContentAsync(relativeUrl, content);
        }

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            OAuthCheck(HttpMethod.Post, relativeUrl);
            return await this.apiClient.PostContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        }

        private async ValueTask<TResult> PostFormAsync<TRequest, TResult>(string relativeUrl, TRequest content)
            where TRequest : class
        {
            OAuthCheck(HttpMethod.Post, relativeUrl);
            return await this.apiClient.PostFormAsync<TRequest, TResult>(
                relativeUrl,
                content);
        }

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content)
        {
            OAuthCheck(HttpMethod.Put, relativeUrl);
            return await this.apiClient.PutContentAsync<T>(relativeUrl, content, "application/json");
        }

        private async ValueTask<TResult> PutAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            OAuthCheck(HttpMethod.Put, relativeUrl);
            return await this.apiClient.PutContentAsync<TRequest, TResult>(relativeUrl, content, "application/json");
        }

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl)
        {
            OAuthCheck(HttpMethod.Delete, relativeUrl);
            return await this.apiClient.DeleteContentAsync<T>(relativeUrl);
        }

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

        // OAUTH
        private void SetOAuthHeader(HttpMethod httpMethod, string relativeUrl)
        {
            var parameters = new SortedDictionary<string, string>
            {
                { "oauth_consumer_key", this.wooCommerceConfigurations.ApiKey },
                { "oauth_signature_method", "HMAC-SHA1" },
                { "oauth_timestamp", GenerateTimestamp() },
                { "oauth_nonce", Guid.NewGuid().ToString("N") }
            };

            var uri = new Uri(this.wooCommerceConfigurations.ApiUrl + relativeUrl);
            string baseUrlWithoutQuery = $"{uri.Scheme}://{uri.Host}{uri.AbsolutePath}";

            var queryParameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
            foreach (var key in queryParameters.AllKeys.OrderBy(k => k))
            {
                parameters.Add(key, queryParameters[key]);
            }

            string parameterString = BuildParameterString(parameters);
            string signatureBaseString = $"{httpMethod.Method.ToUpper()}&{Uri.EscapeDataString(baseUrlWithoutQuery)}&{Uri.EscapeDataString(parameterString)}";
            string signature = GenerateSignature(signatureBaseString, this.wooCommerceConfigurations.ApiSecret);
            parameters.Add("oauth_signature", signature);

            string authorizationHeader = BuildAuthorizationHeader(parameters);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                scheme: "OAuth",
                parameter: authorizationHeader
            );
        }

        private void OAuthCheck(HttpMethod httpMethod, string relativeUrl)
        {
            if (OAuth)
            {
                SetOAuthHeader(httpMethod, relativeUrl);
            }
        }

        static string GenerateTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        }

        static string BuildParameterString(SortedDictionary<string, string> parameters)
        {
            var parameterString = new StringBuilder();
            foreach (var parameter in parameters)
            {
                if (parameterString.Length > 0)
                    parameterString.Append("&");
                parameterString.Append($"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}");
            }
            return parameterString.ToString();
        }

        static string GenerateSignature(string signatureBaseString, string consumerSecret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes($"{consumerSecret}&");
            using (var hmacsha1 = new HMACSHA1(keyBytes))
            {
                byte[] hashBytes = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(signatureBaseString));
                return Convert.ToBase64String(hashBytes);
            }
        }

        static string BuildAuthorizationHeader(SortedDictionary<string, string> parameters)
        {
            var header = new StringBuilder();
            foreach (var parameter in parameters)
            {
                header.Append($"{Uri.EscapeDataString(parameter.Key)}=\"{Uri.EscapeDataString(parameter.Value)}\", ");
            }
            return header.ToString().TrimEnd(' ', ',');
        }
        //END

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);
    }
}
