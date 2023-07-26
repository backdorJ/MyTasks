using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginWebAppWithJWTToken.Models;
using LoginWebAppWithJWTToken.Models.Implementashions;
using LoginWebAppWithJWTToken.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AppContext = LoginWebAppWithJWTToken.Database.AppContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<AppContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectString"));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateAudience = true,
            IssuerSigningKey = AuthOptions.GetKey(),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppContext>();
    db.Database.EnsureCreated();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/login", async (User user, IUserRepository repository) =>
{
    var people = await repository.GetPredicateUserAsync(x => x.Email == user.Email &&
                                                             x.Password == user.Password);
    if (people == null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetKey(), SecurityAlgorithms.HmacSha256)
        );
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        access_token = encodedJwt,
        username = people.Email
    };

    return Results.Json(response);
});

app.MapPost("/signUp", async (HttpContext context,IUserRepository repo) =>
{
    context.Request.ContentType = "application/json";
    var user = await context.Request.ReadFromJsonAsync<User>();
    repo.AddUserAsync(user);
    repo.SaveChangesAsync();
});

app.MapGet("/innerLog", [AuthorizeAttribute]() => new {message = "Hello world!"});

app.Run();

public class AuthOptions
{
    public const string ISSUER = "DamirWebCom";
    public const string AUDIENCE = "client";
    private const string KEY = "121231231231231231231312312";

    public static SymmetricSecurityKey GetKey()
        => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}