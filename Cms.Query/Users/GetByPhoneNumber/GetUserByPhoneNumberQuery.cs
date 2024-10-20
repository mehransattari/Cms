using Cms.Query.Users.DTOs;
using Common.Query;

namespace Cms.Query.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto?>;