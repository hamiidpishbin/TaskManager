using Infrastructure.Data;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServicesConfigurations
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString, message: "Connection String 'DefaultConnection' Not Found");
    services.AddDbContext<ApplicationDbContext>((provider, options) =>
    {
      options.UseSqlServer(connectionString);
      options.AddInterceptors(new SoftDeleteInterceptor());
      options.AddInterceptors(new StatusInterceptor());
      options.AddInterceptors(new AutoDateTimeUpdateInterceptor());
      options.AddInterceptors(new AutoAuditInterceptor(provider));
    });

    return services;
  }
}