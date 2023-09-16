using Domain.Entity;

namespace Domain.Models.Sprint;

public class SprintDto
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfIssues { get; set; }
    public int NumberOfTasks { get; set; }
    public int TaskHoursSum { get; set; }
    public IEnumerable<Issue> Issues { get; set; }
}