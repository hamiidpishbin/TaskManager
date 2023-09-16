using Application.Interfaces;
using Domain.Entity;
using Domain.Interface;
using Infrastructure.Data;

namespace Web.Services;

public class IssueService : IIssueService
{
    private readonly ApplicationDbContext _dbContext;

    public IssueService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Issue> GetIssues()
    {
        return _dbContext.Issues.ToList();
    }
}