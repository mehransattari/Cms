using Common.Application;
using Cms.Application.SiteEntities.Banners.Create;
using Cms.Application.SiteEntities.Banners.Edit;
using Cms.Query.SiteEntities.DTOs;

namespace Cms.Facade.Siteentities.Banner;

public interface IBannerFacade
{
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);

    Task<BannerDto?> GetBannerById(long id);
    Task<List<BannerDto>> GetBanners();
}