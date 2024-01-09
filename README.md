# WooCommerceAPI

## Introduction

This is a new standards compliant library for ecommerce developers. It is under heavy development.

## Critical endpoints done

- Create product (simple, variable, metadata)
- Batch create product attribute / variations
- Upload media (wordpress)
- List all products
- Update a product

## Next

- Delete a product
- Update product variations
- Delete product variations
- Update a media item
- Create a product category
- List all product categories
- List all orders
- Update an order
- Get an order

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

var wooCommerceClient = new WooCommerceClient(wooCommerceConfigurations);

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
