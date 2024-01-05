using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    internal class ExternalProductRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = "simple";

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; } = string.Empty;

        [JsonProperty("attributes")]
        public ExternalProductAttribute[] Attributes { get; set; } = null;

        [JsonProperty("images")]
        public ExternalImage[] Images { get; set; }
    }

    internal class ExternalImage
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        //[JsonProperty("src")]
        //public string Src { get; set; }
    }
}






//public class ProductRequest
//{
//    [JsonProperty("name")]
//    public string Name { get; set; }

//    [JsonProperty("type")]
//    public string Type { get; set; }

//    [JsonProperty("description")]
//    public string Description { get; set; }

//    [JsonProperty("attributes")]
//    public List<ProductAttribute> Attributes { get; set; }

//    [JsonProperty("images")]
//    public List<MediaResponse> Images { get; set; }
//}

//public class VariationRequest
//{
//    [JsonProperty("regular_price")]
//    public string RegularPrice { get; set; }

//    [JsonProperty("attributes")]
//    public List<VariationAttribute> Attributes { get; set; }

//    [JsonProperty("image")]
//    public MediaResponse Image { get; set; }
//}

//public class ProductAttribute
//{
//    [JsonProperty("name")]
//    public string Name { get; set; }

//    [JsonProperty("visible")]
//    public bool Visible { get; set; }

//    [JsonProperty("variation")]
//    public bool Variation { get; set; }

//    [JsonProperty("options")]
//    public List<string> Options { get; set; }
//}

//public class VariationAttribute
//{
//    [JsonProperty("name")]
//    public string Name { get; set; }

//    [JsonProperty("option")]
//    public string Option { get; set; }
//}

//public class BatchVariationRequest
//{
//    [JsonProperty("create")]
//    public List<VariationRequest> Create { get; set; }
//}