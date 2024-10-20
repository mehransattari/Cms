using Cms.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.SiteEntities.Banners.GetList;

public class GetBannerListQueryHandler : IQueryHandler<GetBannerListQuery, List<BannerDto>>
{
    private readonly CmsContext _context;

    public GetBannerListQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Banners.OrderByDescending(d => d.Id)
            .Select(banner => new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            }).ToListAsync(cancellationToken);
    }
}