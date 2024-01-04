using dotenv.net;
using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../../../.env" }));



//var wordPressConfigurations = new WordPressConfigurations
//{
//    UserName = Environment.GetEnvironmentVariable("WP_USER"),
//    AppPassword = Environment.GetEnvironmentVariable("WP_APP_PASSWORD"),
//    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
//};




//var wpclient = new WordPressClient(wordPressConfigurations);

//MediaItem mi = new();
//mi.Request = new();
//mi.Request.Src = @"C:\Users\Brandon\Pictures\2184719.jpeg";

//var r = await wpclient.Media.SendMediaItemAsync(mi);



//return;


var wooCommerceConfigurations = new WooCommerceConfigurations
{
    ApiKey = Environment.GetEnvironmentVariable("WC_CONSUMER_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("WC_CONSUMER_SECRET"),
    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
};

var wooCommerceClient = new WooCommerceClient(wooCommerceConfigurations);


var get = await wooCommerceClient.Products.GetProductAsync(50436);

ProductAttribute[] a = new ProductAttribute[]
{
    new ProductAttribute() {
        Name = "CCC",
        Variation=true,
        Options = new string[] { "Red", "Blue" }
    },
        new ProductAttribute() {
        Name = "ZZZ",
        Variation=true,
        Options = new string[] { "Small", "Medium", "Large" }
    },
};

var inputProduct = new Product
{
    Request = new ProductRequest
    {
        Name = $"name {GenerateUniqueId()}",
        Type = "variable",
        //RegularPrice = "10",
        Attributes = a,
        Images = new ProductImage[] { new ProductImage() { Id = 50413 } }
    }
};

ProductVariationsRequest sourceObject = new ProductVariationsRequest
{
    Create = new[]
    {
        new ProductVariation
        {
            RegularPrice = "1500.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Small" }
            }
        },
                new ProductVariation
        {
            RegularPrice = "1540.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Medium" }
            }
        },
                        new ProductVariation
        {
            RegularPrice = "1250.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Large" }
            }
        },
        new ProductVariation
        {
            RegularPrice = "1150.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Small" }
            }
        },
        new ProductVariation
        {
            RegularPrice = "52.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Medium" }
            }
        },
        new ProductVariation
        {
            RegularPrice = "53.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Large" }
            }
        }
    }
};


Product result = await wooCommerceClient.Products.SendProductAsync(inputProduct);
Console.WriteLine(result.Response.Name);



ProductVariations pv = new()
{
    Request = sourceObject
};
pv.Request.ProductId = result.Response.Id;
var result2 = await wooCommerceClient.Products.SendProductVariationsAsync(pv);
;

long GenerateUniqueId()
{
    long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    int randomNumber = new Random().Next(1000, 9999);

    string uniqueString = $"{timestamp}{randomNumber}";

    if (long.TryParse(uniqueString, out long uniqueId))
    {
        return uniqueId;
    }
    else
    {
        throw new InvalidOperationException("Failed to generate a unique ID.");
    }
}