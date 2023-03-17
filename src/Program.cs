using Azure.Identity;
using cohackapp.Models;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

var useAppConfig = false;
Boolean.TryParse(builder.Configuration["UseAppConfig"], out useAppConfig);

if (useAppConfig)
{
    // Load configuration from Azure App Configuration
    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect(new Uri(builder.Configuration["AppConfigEndpoint"]), new DefaultAzureCredential())
        .ConfigureRefresh(refresh =>
        {
            // Default cache expiration is 30 seconds
            refresh.Register("CoHackApp:Settings:Update", refreshAll: true).SetCacheExpiration(TimeSpan.FromSeconds(10));
        })
        .UseFeatureFlags(featureFlagOptions =>
        {
            // Default cache expiration is 30 seconds
            featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(10);
        })
        // Add Key Vault references
        .ConfigureKeyVault(kv =>
        {
            kv.SetCredential(new DefaultAzureCredential());
        });
    });
}

// Add Azure App Configuration middleware to the container of services.
builder.Services.AddAzureAppConfiguration();

// Add feature management to the container of services.
builder.Services.AddFeatureManagement();

// Bind configuration "CoHackApp:Settings" section to the Settings object
builder.Services.Configure<CoHackAppSettings>(builder.Configuration.GetSection("CoHackApp:Settings"));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (useAppConfig)
{
    // Use Azure App Configuration middleware for dynamic configuration refresh.
    app.UseAzureAppConfiguration();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
