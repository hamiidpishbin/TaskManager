using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {
    if (eventData.Context is null) return result;

    foreach (var entry in eventData.Context.ChangeTracker.Entries())
    {
      if (entry is { State: EntityState.Added, Entity: ISoftDelete added })
      {
        added.IsDeleted = false;
      }

      if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete deleted }) continue;
      entry.State = EntityState.Modified;
      deleted.IsDeleted = true;
    }

    return result;
  }
}