namespace Domain.Interface;

public interface ISoftDelete
{
  bool IsDeleted { get; set; }
}