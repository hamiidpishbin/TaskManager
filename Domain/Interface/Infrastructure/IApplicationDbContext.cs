using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entity.Task;

namespace Domain.Interface.Infrastructure;

public interface IApplicationDbContext
{
  DbSet<Sprint> Sprints { get; }
  DbSet<Issue> Issues { get; }
  DbSet<Task> Tasks { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}