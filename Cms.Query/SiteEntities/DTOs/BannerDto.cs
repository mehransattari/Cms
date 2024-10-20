using Common.Query;
using Cms.Domain.SiteEntities;

namespace Cms.Query.SiteEntities.DTOs;

public class BannerDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}