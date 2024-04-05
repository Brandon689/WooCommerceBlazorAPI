using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var apiKey = builder.Configuration["RestApi:ConsumerKey"];
Console.WriteLine(apiKey);



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


app.MapGet("/products", async () =>
{
    var m = await wooCommerceClient.Products.GetAllProductsAsync(1, 10);
    return m;
})
.WithName("Products")
.WithOpenApi();

app.Run();
