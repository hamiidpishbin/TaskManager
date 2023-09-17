using Application.Interfaces;
using Domain.Entity;
using Domain.Interface;
using Domain.Interface.Infrastructure;
using Infrastructure.Data;

namespace Web.Services;

public class IssueService : IIssueService
{
    private readonly IApplicationDbContext _dbContext;

    public IssueService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Issue> GetIssues()
    {
        return _dbContext.Issues.ToList();
    }
}