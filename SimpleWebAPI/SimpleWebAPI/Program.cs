using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Implementashions;
using SimpleWebAPI.Interfaces;
using SimpleWebAPI.Models;
using AppContext = SimpleWebAPI.Database.AppContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PosgressConntect")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppContext>();
    db.Database.EnsureCreated();
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStatusCodePages(async statusCode =>
{
    var response = statusCode.HttpContext.Response;
    if (response.StatusCode == 404)
        await response.SendFileAsync("HtmlPages/ErrorPage.html");
});

app.MapGet("/users", 
    async (IUserRepository repository) => await repository.GetUsersAsync());
app.MapGet("/users/{id:Guid}",
    async (IUserRepository repository, Guid id) => await repository.GetUserAsync(id));
app.MapPost("/users", async (IUserRepository repository, User user) =>
{
    await repository.AddUserAsync(user);
    await repository.SaveChangesAsync();
});
app.MapPut("/users", async (User user, IUserRepository repository) =>
{
    await repository.UpdateUserAsync(user);
    await repository.SaveChangesAsync();
});
app.MapDelete("/users/{id:Guid}", async (IUserRepository repository, Guid id) =>
{
    await repository.DeleteUserAsync(id);
    await repository.SaveChangesAsync();
});
app.Run();