using Cms.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
{
    private readonly CmsContext _context;

    public GetSliderByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders
            .FirstOrDefaultAsync(f => f.Id == request.SliderId, cancellationToken);
        if (slider == null)
            return null;

        return new SliderDto()
        {
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            ImageName = slider.ImageName,
            Link = slider.Link,
            Title = slider.Title
        };
    }
}