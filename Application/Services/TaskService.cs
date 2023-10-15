using Application.Helpers;
using Application.Interfaces;
using Application.Models;
using Application.Models.UserTask;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class TaskService : ITaskService
{
  private readonly IApplicationDbContext _context;
  private readonly IMapper _mapper;

  public TaskService(IApplicationDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<OldResult<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto)
  {
    var userTasks = await _context.Tasks.Where(u => u.Id == getUserTasksDto.Id).ToListAsync();
    var result = _mapper.Map<List<UserTaskDto>>(userTasks);
    return OldResult<List<UserTaskDto>>.Success(result);
  }

  public async Task<OldResult<bool>> AddUserTask(AddUserTaskDto addUserTaskDto)
  {
    var userTask = _mapper.Map<UserTask>(addUserTaskDto);
    _context.Tasks.Add(userTask);
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result
      ? OldResult<bool>.Success(true)
      : OldResult<bool>.Failure(LogHelper.GetFailureLog("Add Task"));
  }
}