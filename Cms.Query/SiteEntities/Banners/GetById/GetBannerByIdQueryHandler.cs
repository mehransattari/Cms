using Cms.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
{
    private readonly CmsContext _context;

    public GetBannerByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.FirstOrDefaultAsync(f => f.Id == request.BannerId, cancellationToken);
        if (banner == null)
            return null;

        return new BannerDto()
        {
            Id = banner.Id,
            CreationDate = banner.CreationDate,
            ImageName = banner.ImageName,
            Link = banner.Link,
            Position = banner.Position
        };
    }
}