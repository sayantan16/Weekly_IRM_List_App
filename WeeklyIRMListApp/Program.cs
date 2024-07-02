using Microsoft.EntityFrameworkCore;
using WeeklyIRMListApp.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

var services = builder.Services;
var configuration = builder.Configuration;

var serverName = Environment.GetEnvironmentVariable("ServerName");
var databaseName = Environment.GetEnvironmentVariable("DatabaseName");
var userId = Environment.GetEnvironmentVariable("UserId");
var password = Environment.GetEnvironmentVariable("Password");

string connectionString;
if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
{
    // Use Windows Authentication
    connectionString = configuration.GetConnectionString("DefaultConnectionString")
        .Replace("{ServerName}", serverName)
        .Replace("{DatabaseName}", databaseName)
        .Replace("{Authentication}", "Trusted_Connection=True;");
}
else
{
    // Use SQL Server Authentication
    connectionString = configuration.GetConnectionString("DefaultConnectionString")
        .Replace("{ServerName}", serverName)
        .Replace("{DatabaseName}", databaseName)
        .Replace("{Authentication}", $"User Id={userId};Password={password};");
}

Console.WriteLine($"ConnectionString: {connectionString}");

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WeeklyIrmlist}/{action=Index}/{id?}");

app.Run();
