using System.Reflection;
using Domain.Entity;
using Infrastructure.Identity;
using Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entity.Task;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<Sprint> Sprints => Set<Sprint>();
  public DbSet<Issue> Issues => Set<Issue>();
  public DbSet<Task> Tasks => Set<Task>();

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