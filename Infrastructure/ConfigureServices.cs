using Application.Interfaces;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString, message: "Connection String 'DefaultConnection' NOt Found");
    services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });

    return services;
  }
}