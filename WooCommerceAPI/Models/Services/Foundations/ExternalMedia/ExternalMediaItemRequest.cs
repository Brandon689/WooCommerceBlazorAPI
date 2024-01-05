using RESTFulSense.Models.Attributes;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalMedia
{
    internal class ExternalMediaItemRequest
    {
        [RESTFulStreamContent("file")]
        public Stream File { get; set; }

        [RESTFulFileName("file")]
        public string FileName { get; set; }

        [RESTFulStringContent("Alt-Text")]
        public string AltText { get; set; }
    }
}
