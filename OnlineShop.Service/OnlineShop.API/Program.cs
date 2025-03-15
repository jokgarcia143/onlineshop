using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineShop.API.Models;
using OnlineShop.API.Data;
using Microsoft.AspNetCore.Authentication;
using OnlineShop.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OnlineShopContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("BeviConnectionString")));

//Identity-------
builder.Services.AddIdentity<SystemUser, IdentityRole>()
    .AddEntityFrameworkStores<OnlineShopContext>()
    .AddDefaultTokenProviders();

//Register Services
builder.Services.AddSingleton(new OnlineShop.API.Services.AuthenticationService(builder.Configuration.GetValue<string>("JWT:SecretKey")));
//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.Configure<IdentityOptions>(options => 
{
    options.Password.RequiredLength = 8;
});
//Identity-------



builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
