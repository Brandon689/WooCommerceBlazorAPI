//using Newtonsoft.Json;
//using System.Text;
//using WooCommerceAPI.Models.Services.Foundations.Products;
Console.WriteLine();
//Product k = new()
//{
//    Request = new ProductRequest()
//    {
//        Name = "spec",
//        RegularPrice = "711"
//    }
//};

//var externalProductRequest = ConvertToProductRequest(k);


//ConvertToJsonStringContent<EXO>(externalProductRequest, "application/json", true);

//StringContent ConvertToJsonStringContent<T>(T content, string mediaType, bool ignoreDefaultValues)
//{
//    JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings(ignoreDefaultValues);

//    string serializedRestrictionRequest = JsonConvert.SerializeObject(
//        content,
//        formatting: Formatting.Indented,
//        settings: jsonSerializerSettings);
//    File.WriteAllText("C:\\Logs\\updateproduct3.json", serializedRestrictionRequest);

//    var contentString =
//        new StringContent(
//            content: serializedRestrictionRequest,
//            encoding: Encoding.UTF8,
//            mediaType);

//    return contentString;
//}
//JsonSerializerSettings CreateJsonSerializerSettings(bool ignoreDefaultValues)
//{
//    DefaultValueHandling defaultValueHandling = ignoreDefaultValues ? DefaultValueHandling.Ignore : DefaultValueHandling.Include;
//    var jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = defaultValueHandling };
//    return jsonSerializerSettings;
//}



//EXO ConvertToProductRequest(Product product)
//{
//    var externalProductRequest = new EXO()
//    {
//        Name = product.Request.Name,
//        RegularPrice = product.Request.RegularPrice,
//        Description = product.Request.Description,
//        Type = product.Request.Type,
//        StockQuantity = product.Request.StockQuantity,
//        CatalogVisibility = product.Request.CatalogVisibility,
//        ShortDescription = product.Request.ShortDescription,
//        Featured = product.Request.Featured,
//        StockStatus = product.Request.StockStatus,
//        Slug = product.Request.Slug,
//        Sku = product.Request.Sku,
//    };

//    return externalProductRequest;
//}




//[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
//public class EXO
//{
//    [JsonProperty("name")]
//    public string? Name { get; set; }

//    [JsonProperty("type")]
//    public string? Type { get; set; } = "simple";

//    [JsonProperty("description")]
//    public string? Description { get; set; }

//    [JsonProperty("regular_price")]
//    public string? RegularPrice { get; set; }

//    [JsonProperty("slug")]
//    public string? Slug { get; set; }

//    [JsonProperty("status")]
//    public string? Status { get; set; }

//    [JsonProperty("featured")]
//    public bool? Featured { get; set; }

//    [JsonProperty("catalog_visibility")]
//    public string? CatalogVisibility { get; set; }

//    [JsonProperty("short_description")]
//    public string? ShortDescription { get; set; }

//    [JsonProperty("sku")]
//    public string? Sku { get; set; }

//    [JsonProperty("manage_stock")]
//    public bool? ManageStock { get; set; }

//    [JsonProperty("stock_quantity")]
//    public int? StockQuantity { get; set; }

//    [JsonProperty("stock_status")]
//    public string? StockStatus { get; set; }

//}