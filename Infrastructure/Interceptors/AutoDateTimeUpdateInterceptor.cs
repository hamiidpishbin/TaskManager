using Application.Common.Interfaces.Web;
using Domain.Enums;
using Domain.Interface;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public class AutoDateTimeUpdateInterceptor : SaveChangesInterceptor
{
  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {
    if (eventData.Context is null) return result;

    foreach (var entry in eventData.Context.ChangeTracker.Entries())
    {
      if (entry is not { State: EntityState.Modified, Entity: IAutoDateTimeUpdate entity and IStatus status }) continue;

      switch (status.Status)
      {
        case Status.Active:
          entity.Start = DateTime.Now;
          break;
        case Status.Closed:
          entity.End = DateTime.Now;
          break;
      }
    }

    return result;
  }
}