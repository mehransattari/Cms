using Common.Application;
using MediatR;
using Cms.Application.Users.AddAddress;
using Cms.Application.Users.EditAddress;
using Cms.Application.Users.DeleteAddress;
using Cms.Query.Users.DTOs;
using Cms.Query.Users.Addresses.GetById;
using Cms.Query.Users.Addresses.GetList;

namespace Cms.Facade.Users.Addresses;

internal class UserAddressFacade : IUserAddressFacade
{
    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<AddressDto?> GetById(long userAddressId)
    {
        return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));
    }

    public async Task<List<AddressDto>> GetList(long userId)
    {
        return await _mediator.Send(new GetUserAddressesListQuery(userId));
    }
}