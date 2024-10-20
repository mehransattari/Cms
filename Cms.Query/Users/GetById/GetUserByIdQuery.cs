using Cms.Query.Users.DTOs;
using Common.Query;

namespace Cms.Query.Users.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }

    public long UserId { get; private set; }
}