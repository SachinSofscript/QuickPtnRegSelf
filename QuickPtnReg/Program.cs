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
else
{
    app.UseDeveloperExceptionPage(); // For local dev
}
 
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
