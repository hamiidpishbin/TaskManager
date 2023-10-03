using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesConfigurations
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<ISprintService, SprintService>();
    services.AddScoped<ITaskService, TaskService>();
    return services;
  }
}