using Common.Application;
using MediatR;
using Cms.Application.SiteEntities.Sliders.Create;
using Cms.Application.SiteEntities.Sliders.Edit;
using Cms.Query.SiteEntities.DTOs;
using Cms.Query.SiteEntities.Sliders.GetById;
using Cms.Query.SiteEntities.Sliders.GetList;

namespace Cms.Facade.Siteentities.Slider;

internal class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;

    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSlider(EditSliderCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<SliderDto?> GetSliderById(long id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));

    }
    public async Task<List<SliderDto>> GetSliders()
    {
        return await _mediator.Send(new GetSliderListQuery());
    }
}