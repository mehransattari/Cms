using Cms.Query.Users.DTOs;
using Common.Query;

namespace Cms.Query.Users.Addresses.GetById;
public record GetUserAddressByIdQuery(long AddressId) : IQuery<AddressDto?>;
