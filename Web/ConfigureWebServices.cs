using System.Text;
using Application.Interfaces;
using Application.Models;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Web.Services;

namespace Web;

public static class ConfigureWebServices
{
  public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
  {
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<ISprintService, SprintService>();

    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        policyBuilder => { policyBuilder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); });
    });

    services.AddIdentityCore<AppUser>()
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
    {
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    });

    return services;
  }
}