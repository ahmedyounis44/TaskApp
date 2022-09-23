using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TaskApp.Data;
using TaskApp.Data.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClasessService>();
builder.Services.AddScoped<CountriesService>();
builder.Services.AddScoped<StudentsService>();
builder.Services.AddScoped<StatisticsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}


app.Run();
