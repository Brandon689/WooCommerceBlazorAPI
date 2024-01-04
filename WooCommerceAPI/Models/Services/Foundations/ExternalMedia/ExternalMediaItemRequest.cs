using Newtonsoft.Json;
using RESTFulSense.Models.Attributes;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalMedia
{
    internal class ExternalMediaItemRequest
    {
        //[JsonProperty("id")]
        //public int Id { get; set; } = 0;

        //[JsonProperty("src")]
        //public string Src { get; set; } = string.Empty;

        //[JsonProperty("name")]
        //public string Name { get; set; } = string.Empty;

        //[JsonProperty("alt")]
        //public string Alt { get; set; } = string.Empty;


        [RESTFulStreamContent("file")]
        public Stream File { get; set; }

        [RESTFulFileName("file")]
        public string FileName { get; set; }

        [RESTFulStringContent("Alt-Text")]
        public string AltText { get; set; }
    }

    internal class ExternalMediaItemRequest2
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("src")]
        public string Src { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("alt")]
        public string Alt { get; set; } = string.Empty;
    }
}
