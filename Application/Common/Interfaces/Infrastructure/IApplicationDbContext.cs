using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Infrastructure;

public interface IApplicationDbContext
{
  DbSet<Domain.Entities.Sprint> Sprints { get; }
  DbSet<Issue> Issues { get; }
  DbSet<Domain.Entities.UserTask> Tasks { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}