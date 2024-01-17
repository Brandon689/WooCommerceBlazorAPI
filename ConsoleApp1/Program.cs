using dotenv.net;
using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

DotEnv.Load();

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
//var get = await wooCommerceClient.Products.GetProductAsync(50674);

var vtf= await wooCommerceClient.Orders.GetOrderAsync(50693);


Product k = new()
{
    Name = "spec",
    RegularPrice = "711"
};


var u6p = await wooCommerceClient.Products.UpdateProductAsync(k, 50444);







var getAll = await wooCommerceClient.Products.GetAllProductsAsync(4, 100);

var up = await wooCommerceClient.Products.UpdateProductAsync(k, 50674);





var inputProduct2 = new Product
{
        Name = $"title {GenerateUniqueId()}",
        Type = "simple",
        RegularPrice = "1",
        //Images = new I[] { new ID() { Id = 50413 } },
        MetaData = new ProductMetadata[]
        {
            new ProductMetadata() { Key = "simon", Value = "kruger" },
            new ProductMetadata() { Key = "tony", Value = "robbins" }
        }
    
};

Product result3 = await wooCommerceClient.Products.SendProductAsync(inputProduct2);
Console.WriteLine(result3.Name);


//var getAll = await wooCommerceClient.Products.GetAllProductsAsync(4, 100);



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
        Name = $"name {GenerateUniqueId()}",
        Type = "variable",
        //RegularPrice = "10",
        Attributes = a,
        ///Images = new ID[] { new ID() { Id = 50413 } }
    
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
            },
            Image = new ID() { Id = 50522 }
        },
        new ProductVariation
        {
            RegularPrice = "1540.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Medium" }
            },
            Image = new ID() { Id = 50413 }

        },
        new ProductVariation
        {
            RegularPrice = "1250.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Red" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Large" }
            },
            Image = new ID() { Id = 50304 }

        },
        new ProductVariation
        {
            RegularPrice = "1150.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Small" }
            },
            Image = new ID() { Id = 49937 }

        },
        new ProductVariation
        {
            RegularPrice = "52.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Medium" }
            },
            Image = new ID() { Id = 49782 }

        },
        new ProductVariation
        {
            RegularPrice = "53.00",
            Attributes = new[]
            {
                new ProductVariationAttribute { Name = "CCC", Option = "Blue" },
                new ProductVariationAttribute { Name = "ZZZ", Option = "Large" }
            },
            Image = new ID() { Id = 49761 }
        }
    }
};


Product result = await wooCommerceClient.Products.SendProductAsync(inputProduct);
Console.WriteLine(result.Name);



ProductVariations pv = new()
{
    Request = sourceObject
};
pv.Request.ProductId = (int)result.Id;
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