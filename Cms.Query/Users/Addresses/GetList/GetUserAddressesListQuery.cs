using Cms.Query.Users.DTOs;
using Common.Query;
namespace Cms.Query.Users.Addresses.GetList;
public record GetUserAddressesListQuery(long UserId) : IQuery<List<AddressDto>>;