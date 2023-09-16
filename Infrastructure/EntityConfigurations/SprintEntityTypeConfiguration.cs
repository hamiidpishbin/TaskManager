using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entity.Task;

namespace Infrastructure.EntityConfigurations;

public class SprintEntityTypeConfiguration : IEntityTypeConfiguration<Sprint>
{
  public void Configure(EntityTypeBuilder<Sprint> builder)
  {
    builder
      .HasMany(e => e.Tasks)
      .WithOne(e => e.Sprint)
      .HasForeignKey(e => e.SprintId)
      .HasPrincipalKey(e => e.Id);
  }
}