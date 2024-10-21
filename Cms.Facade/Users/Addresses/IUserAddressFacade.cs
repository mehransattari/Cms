using Common.Application;
using Cms.Application.Users.AddAddress;
using Cms.Application.Users.EditAddress;
using Cms.Application.Users.DeleteAddress;
using Cms.Query.Users.DTOs;

namespace Cms.Facade.Users.Addresses;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddUserAddressCommand command);

    Task<OperationResult> EditAddress(EditUserAddressCommand command);

    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

    Task<AddressDto?> GetById(long userAddressId);

    Task<List<AddressDto>> GetList(long userId);

}