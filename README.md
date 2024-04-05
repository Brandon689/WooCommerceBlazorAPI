# WooCommerceAPI

## Introduction

WooCommerce .NET Api and Blazor Server Admin Panel for ecommerce developers.


## Note
It is recommended that you utilize a dockerized WordPress dev environment for testing.
Here is the needed instructions to get started, just install Docker and then follow along:
https://github.com/docker/awesome-compose/tree/master/official-documentation-samples/wordpress/
* Basic Auth is not supported by WooCommerce over HTTP, therefore use OAuth.

## Swagger
There is now a ASP.NET core server with Swagger Docs

## endpoints done

- Create product (simple, variable, metadata)
- Batch create product attribute / variations
- Upload media (wordpress)
- List all products
- Update a product
- Update product variations
- Get product variations
- Get an order
- List all orders
- Update a media item
## Next

- Delete a product
- Delete product variations
- Create a product category
- List all product categories
- Update an order


## Hello World

```csharp
using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;
using dotenv.net;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../../../.env" }));

var wooCommerceConfigurations = new WooCommerceConfigurations
{
    ApiKey = Environment.GetEnvironmentVariable("WC_CONSUMER_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("WC_CONSUMER_SECRET"),
    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
};

var wooCommerceClient = new WooCommerceClient(wooCommerceConfigurations, true);

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

Product result = await wooCommerceClient.Products.SendProductAsync(inputProduct);
Console.WriteLine(result.Response.Name);
```


## Acknowledgements
Thanks to [hassanhabib](https://github.com/hassanhabib) for the coding Standard.
