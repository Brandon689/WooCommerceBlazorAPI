using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Orders;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var wooCommerceConfigurations = new WooCommerceConfigurations
{
    ApiKey = builder.Configuration["RestApi:ConsumerKey"],
    ApiSecret = builder.Configuration["RestApi:ConsumerSecret"],
    ApiUrl = builder.Configuration["RestApi:BaseUrl"]
};


var wooCommerceClient = new WooCommerceClient(wooCommerceConfigurations, oAuth: true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products/{id}", async (int id) =>
{
    var product = await wooCommerceClient.Products.GetProductAsync(id);
    return product;
})
.WithName("GetProductById")
.WithOpenApi();

app.MapGet("/products", async (int page, int perPage) =>
{
    var products = await wooCommerceClient.Products.GetAllProductsAsync(page, perPage);
    return products;
})
.WithName("GetAllProducts")
.WithOpenApi();

app.MapPost("/products/{id}/variations", async (ProductVariations request, int productId) =>
{
    var product = await wooCommerceClient.Products.SendProductVariationsAsync(request);
    return product;
})
.WithName("PostProductVariations")
.WithOpenApi();

app.MapPut("/products/{id}", async (Product product, int id) =>
{
    var updatedProduct = await wooCommerceClient.Products.UpdateProductAsync(product, id);
    return updatedProduct;
})
.WithName("UpdateProduct")
.WithOpenApi();

app.MapGet("/products/{id}/variations", async (int id) =>
{
    var variations = await wooCommerceClient.Products.GetProductVariations(id);
    return variations;
})
.WithName("GetProductVariations")
.WithOpenApi();

app.MapGet("/orders/{id}", async (int id) =>
{
    var order = await wooCommerceClient.Orders.GetOrderAsync(id);
    return order;
})
.WithName("GetOrderById")
.WithOpenApi();

app.MapGet("/orders", async (int page, int perPage) =>
{
    var orders = await wooCommerceClient.Orders.GetAllOrdersAsync(page, perPage);
    return orders;
})
.WithName("GetAllOrders")
.WithOpenApi();

app.MapPost("/orders", async (Order request) =>
{
    var newOrder = await wooCommerceClient.Orders.CreateOrderAsync(request);
    return newOrder;
})
.WithName("CreateOrder")
.WithOpenApi();

app.Run();
