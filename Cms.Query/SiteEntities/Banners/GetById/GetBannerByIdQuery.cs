using Cms.Query.SiteEntities.DTOs;
using Common.Query;

namespace Cms.Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;