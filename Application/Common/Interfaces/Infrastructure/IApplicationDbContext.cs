using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Application.Common.Interfaces.Infrastructure;

public interface IApplicationDbContext
{
  DbSet<Sprint> Sprints { get; }
  DbSet<Issue> Issues { get; }
  DbSet<Task> Tasks { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}