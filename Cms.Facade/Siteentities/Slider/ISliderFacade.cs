using Common.Application;
using Cms.Application.SiteEntities.Sliders.Create;
using Cms.Application.SiteEntities.Sliders.Edit;
using Cms.Query.SiteEntities.DTOs;

namespace Cms.Facade.Siteentities.Slider;

public interface ISliderFacade
{
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);

    Task<SliderDto?> GetSliderById(long id);
    Task<List<SliderDto>> GetSliders();
}