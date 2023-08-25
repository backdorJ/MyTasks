using FleaMarket.API.Interaces;
using FleaMarket.API.Interaces.Implementashion;
using FleaMarket.Authoriz;
using FleaMarket.Data;
using FleaMarket.Implentashions;
using FleaMarket.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddHttpClient<IBeerRepository, BeerRepository>(client =>
{
    client.BaseAddress = new Uri("https://random-data-api.com/api/v2/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<IUserRepository, UserRepository>(client =>
{
    client.BaseAddress = new Uri("https://random-data-api.com/api/v2/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.AddHttpClient<IFoodRepository, FoodRepository>(client =>
{
    client.BaseAddress = new Uri("https://api.spoonacular.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("x-api-key", builder.Configuration["ApiKey"]);
});
builder.Services.AddScoped<IAnnouncementsRepository, SQLAnnouncementRepository>();
builder.Services.AddScoped<IRecipeRepository, SQLRecipeRepository>();
builder.Services.AddLogging(options => options.AddSerilog());

builder.Services.AddDefaultIdentity<ApplicationUser>(opt =>
        opt.Password.RequireNonAlphanumeric = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
    options.LoginPath = "/Account/Login");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=ViewAnnouncements}/{id?}");

app.Run();