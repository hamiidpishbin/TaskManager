using System.Reflection;
using Application.Common.Interfaces.Infrastructure;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Interceptors;
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

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    optionsBuilder.AddInterceptors(new StatusInterceptor());
    optionsBuilder.AddInterceptors(new AutoDateTimeUpdateInterceptor());
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }
}