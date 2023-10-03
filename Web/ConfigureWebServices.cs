using System.Text;
using Application.Common.Interfaces.Infrastructure;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Common;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Web.Services;

namespace Web;

public static class ConfigureWebServices
{
  public static IServiceCollection AddWebServices(this IServiceCollection services,
    IConfiguration config)
  {
    services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<ITokenService, TokenService>();

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

    services.AddControllers(options =>
    {
      var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
      options.Filters.Add(new AuthorizeFilter(policy));
    });

    return services;
  }
}