using DNTCaptcha.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Ui.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Optional: logs to terminal
    .WriteTo.File("Logs/app-log-.txt", rollingInterval: RollingInterval.Day) // Logs go into Logs folder
    .Enrich.FromLogContext()
    .CreateLogger();

// Step 2: Use Serilog as logging provider
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddRazorPages(options =>
//{
//    options.RootDirectory = "/Pages/";
//    options.Conventions.AuthorizeFolder("/");
//});
var encryptionKey = builder.Configuration["DNTCaptcha:EncryptionKey"];
if (string.IsNullOrWhiteSpace(encryptionKey))
{
    throw new Exception("DNTCaptcha EncryptionKey is missing in configuration.");
}

builder.Services.AddDNTCaptcha(options =>
{
    options.UseCookieStorageProvider()
           .ShowThousandsSeparators(false)
           .WithEncryptionKey(encryptionKey);
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // For local dev
}

var forwardedHeaderOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
};

forwardedHeaderOptions.KnownNetworks.Clear();
forwardedHeaderOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardedHeaderOptions);
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
