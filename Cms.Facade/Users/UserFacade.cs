using Common.Application;
using MediatR;
using Cms.Application.Users.Create;
using Cms.Application.Users.Edit;
using Cms.Application.Users.Register;
using Cms.Query.Users.DTOs;
using Cms.Query.Users.GetByFilter;
using Cms.Query.Users.GetById;
using Cms.Query.Users.GetByPhoneNumber;

namespace Cms.Facade.Users;

internal class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}