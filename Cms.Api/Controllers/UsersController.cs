using Cms.Application.Users.Create;
using Cms.Application.Users.Edit;
using Cms.Facade.Users;
using Cms.Query.Users.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;
    public UsersController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers(UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit(EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }
}