using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
  DbSet<Sprint> Sprints { get; }
  DbSet<Issue> Issues { get; }
  DbSet<UserTask> Tasks { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}