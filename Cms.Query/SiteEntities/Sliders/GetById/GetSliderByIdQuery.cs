using Cms.Query.SiteEntities.DTOs;
using Common.Query;

namespace Cms.Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;
