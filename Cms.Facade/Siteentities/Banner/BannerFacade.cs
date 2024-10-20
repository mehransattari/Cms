using Common.Application;
using MediatR;
using Cms.Application.SiteEntities.Banners.Create;
using Cms.Application.SiteEntities.Banners.Edit;
using Cms.Query.SiteEntities.Banners.GetById;
using Cms.Query.SiteEntities.Banners.GetList;
using Cms.Query.SiteEntities.DTOs;

namespace Cms.Facade.Siteentities.Banner;

internal class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditBanner(EditBannerCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<BannerDto?> GetBannerById(long id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));

    }

    public async Task<List<BannerDto>> GetBanners()
    {
        return await _mediator.Send(new GetBannerListQuery());

    }


}