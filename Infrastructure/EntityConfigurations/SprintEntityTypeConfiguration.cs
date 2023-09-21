using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entities.Task;

namespace Infrastructure.EntityConfigurations;

public class SprintEntityTypeConfiguration : IEntityTypeConfiguration<Sprint>
{
  public void Configure(EntityTypeBuilder<Sprint> builder)
  {
    builder
      .HasQueryFilter(e => e.IsDeleted == false)
      .HasMany(e => e.Tasks)
      .WithOne(e => e.Sprint)
      .HasForeignKey(e => e.SprintId)
      .HasPrincipalKey(e => e.Id);
  }
}