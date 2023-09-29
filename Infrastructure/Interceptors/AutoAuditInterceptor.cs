using Application.Common.Interfaces.Infrastructure;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Interceptors;

public class AutoAuditInterceptor : SaveChangesInterceptor
{
  private readonly IServiceProvider _serviceProvider;

  public AutoAuditInterceptor(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
    CancellationToken cancellationToken = new CancellationToken())
  {
    if (eventData.Context is null) return result;

    var identityService = _serviceProvider.GetRequiredService<IIdentityService>();
    var currentUser = await identityService.GetCurrentUser();
    var currentUserId = currentUser.Id;

    foreach (var entry in eventData.Context.ChangeTracker.Entries())
    {
      if (entry is { State: EntityState.Added, Entity: BaseAuditableEntity baseEntity })
      {
        baseEntity.CreatedAt = DateTime.Now;
        baseEntity.CreatedBy = currentUserId;
        baseEntity.LastModifiedAt = DateTime.Now;
        baseEntity.LastModifiedBy = currentUserId;
      }

      if (entry is not { State: EntityState.Modified or EntityState.Deleted, Entity: BaseAuditableEntity baseAuditableEntity }) continue;
      baseAuditableEntity.LastModifiedAt = DateTime.Now;
      baseAuditableEntity.LastModifiedBy = currentUserId;
    }

    return result;
  }
}