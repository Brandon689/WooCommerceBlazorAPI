# WooCommerceAPI

## Introduction

This is a new standards compliant library for ecommerce developers. It is under heavy development.

Thanks to [@hassanhabib] for his coding Standard.


## Hello World

```
using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using dotenv.net;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../../../.env" }));

var openAIConfigurations = new WooCommerceConfigurations
{
    ApiKey = Environment.GetEnvironmentVariable("WC_CONSUMER_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("WC_CONSUMER_SECRET"),
    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
};

var openAIClient = new WooCommerceClient(openAIConfigurations);

ProductAttribute[] a = new ProductAttribute[3];


var inputProduct = new Product
{
    Request = new ProductRequest
    {
        Name = "name 5",
        Type = "simple",
        RegularPrice = "10",
        //Attributes = a
    }
};

Product result = await openAIClient.Products.SendProductAsync(inputProduct);
Console.WriteLine(result.Response.Name);
```
