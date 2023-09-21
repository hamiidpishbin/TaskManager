using System.Text;
using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Sprints.Queries;
using Domain.Interface;
using Domain.Interfaces;
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
    services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<ISprintService, SprintService>();
    services.AddScoped<ITaskService, TaskService>();

    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        policyBuilder => { policyBuilder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); });
    });

    services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(GetSprintsQuery).Assembly));

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