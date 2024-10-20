using Common.Application;
using Cms.Application.Users.AddAddress;
using Cms.Application.Users.EditAddress;

namespace Cms.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);

        Task<OperationResult> EditAddress(EditUserAddressCommand command);
    }
}