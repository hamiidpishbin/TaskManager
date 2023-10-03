using Application.Dtos.UserTask;
using Application.Helpers;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
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

  public async Task<Result<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto)
  {
    var userTasks = await _context.Tasks.Where(u => u.Id == getUserTasksDto.Id).ToListAsync();
    var result = _mapper.Map<List<UserTaskDto>>(userTasks);
    return Result<List<UserTaskDto>>.Success(result);
  }

  public async Task<Result<bool>> AddUserTask(AddUserTaskDto addUserTaskDto)
  {
    var userTask = _mapper.Map<UserTask>(addUserTaskDto);
    _context.Tasks.Add(userTask);
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result
      ? Result<bool>.Success(true)
      : Result<bool>.Failure(LogHelper.GetFailureLog("Add Task"));
  }
}