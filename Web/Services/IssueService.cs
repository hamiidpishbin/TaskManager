using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Domain.Entities;
using Domain.Interface;
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