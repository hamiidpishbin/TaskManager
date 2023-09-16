using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entity.Task;

namespace Infrastructure.EntityConfigurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
{
  public void Configure(EntityTypeBuilder<Task> builder)
  {
    builder.HasQueryFilter(x => x.IsDeleted == false);
  }
}