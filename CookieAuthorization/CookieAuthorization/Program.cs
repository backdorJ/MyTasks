using System.Security.Claims;
using CookieAuthorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var adminRole = new Role("admin");
var userRole = new Role("user");
var peoples = new List<User>()
{
    new User("tom@gmail.com", "12345", adminRole),
    new User("damir@gmail.com", "1213", userRole)
};
var builder = WebApplication.CreateBuilder();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessDenied";
    });
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/accessDenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied!");
});

app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("Pages/loginPage.html");
});

app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    var form = context.Request.Form;

    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest();

    var email = form["email"];
    var password = form["password"];

    var user = peoples.FirstOrDefault(x => x.Email == email && x.Password == password);
    if (user == null) return Results.Unauthorized();

    var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(ClaimTypes.Role, user.Role.Name)
    };

    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPer = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPer);
    return Results.Redirect(returnUrl ?? "/");
});

app.Map("/admin", [Authorize(Roles = "admin")]() => "Hello admin panel active");

app.Map("/", [Authorize(Roles = "admin,user")] async (HttpContext context) =>
{
    context.Response.ContentType = "text/plain; charset=utf-8";
    var login = context.User.FindFirst(ClaimTypes.Name);
    var role = context.User.FindFirst(ClaimTypes.Role);

    await context.Response.WriteAsync($"Hello: {login.Value} Your role: {role.Value}!");
});

app.Run();

record Person(string Email, string Password);