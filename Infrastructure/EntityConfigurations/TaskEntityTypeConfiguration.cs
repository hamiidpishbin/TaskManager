using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<UserTask>
{
  public void Configure(EntityTypeBuilder<UserTask> builder)
  {
    builder.HasQueryFilter(x => x.IsDeleted == false);
  }
}