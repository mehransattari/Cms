using Cms.Query.Users;
using Cms.Query.Users.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Users.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly CmsContext _context;

    public GetUserByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
            return null;


        return await user.Map().SetUserRoleTitles(_context);
    }
}