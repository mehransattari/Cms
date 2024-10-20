using Cms.Query.Users;
using Cms.Query.Users.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly CmsContext _context;

    public GetUserByPhoneNumberQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber, cancellationToken);

        if (user == null)
            return null;


        return await user.Map().SetUserRoleTitles(_context);
    }
}