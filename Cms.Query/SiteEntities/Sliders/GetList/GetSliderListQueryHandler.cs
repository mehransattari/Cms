using Cms.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.SiteEntities.Sliders.GetList;

public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    private readonly CmsContext _context;

    public GetSliderListQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sliders.OrderByDescending(d => d.Id)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
    }
}