using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    public class ID
    {
        public int Id { get; set; }

        public ID()
        { }

        public ID(int id)
        {
            Id = id;
        }
    }

    internal class ExternalID
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public ExternalID()
        { }

        public ExternalID(int id)
        {
            Id = id;
        }
    }
}
