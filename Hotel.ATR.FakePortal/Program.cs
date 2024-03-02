using Hotel.ATR.FakePortal.Models;
using Serilog;
using Npgsql;
using NpgsqlTypes;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

string connString = "Host=127.0.0.1;Port=5435;Database=nurbolatzursinbek;Username=nurbolatzursinbek;";
using (var conn = new NpgsqlConnection(connString))
{
    try
    {
        conn.Open();
        Console.WriteLine("Успешное подключение!");


        conn.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка подключения: {ex.Message}");
    }
}





//IHostBuilder hostBuilder = builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
//{
//    loggerConfiguration
//        .MinimumLevel.Information()
//        .WriteTo.Console()
//        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day); 
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/login";
    });
//TODO
//builder.Services.Configure<CookieBuilder>
//    (options =>
//    {
//        options.
//    });
//TODO 
//builder.Services.AddDistributedMemoryCache({
//    Services.AddSession();
//});


////builder.WebHost.ConfigureLogging(logging =>
//{
//    logging.ClearProviders();
//    logging.AddDebug().
//    AddConsole().
//    AddSeq();
//});



// Add services to the container.
builder.Services.AddControllersWithViews();
//TODO
//builder.Services.AddTransient<IRepository. RepositorySQL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}   
app.UseStaticFiles();

//TODO
//app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
//    http://localhost:5203
//    {controler}
//    {action}
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

