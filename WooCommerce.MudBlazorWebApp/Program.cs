using dotenv.net;
using MudBlazor.Services;
using WooCommerce.MudBlazorWebApp.Components;
using WooCommerce.MudBlazorWebApp.Services;
using WooCommerceAPI.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

DotEnv.Load();

var wooCommerceConfigurations = new WooCommerceConfigurations
{
    ApiKey = Environment.GetEnvironmentVariable("WC_CONSUMER_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("WC_CONSUMER_SECRET"),
    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
};

builder.Services.AddSingleton(wooCommerceConfigurations);
builder.Services.AddScoped<WooCommerceService>();
builder.Services.AddScoped<CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
