using System.Reflection;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<Sprint> Sprints => Set<Sprint>();
  public DbSet<Issue> Issues => Set<Issue>();
  public DbSet<UserTask> Tasks => Set<UserTask>();

  public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = new CancellationToken())
  {
    return await base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }
}