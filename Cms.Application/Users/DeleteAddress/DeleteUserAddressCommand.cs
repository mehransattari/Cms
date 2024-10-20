using Common.Application;

namespace Cms.Application.Users.DeleteAddress;

public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;