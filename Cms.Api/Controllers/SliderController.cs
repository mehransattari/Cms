using Cms.Application.SiteEntities.Sliders.Create;
using Cms.Application.SiteEntities.Sliders.Edit;
using Cms.Facade.Siteentities.Slider;
using Cms.Query.SiteEntities.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class SliderController : ApiController
{
    private readonly ISliderFacade _facade;
    public SliderController(ISliderFacade facade)
    {
        _facade = facade;
    }
    [HttpGet]
    public async Task<ApiResult<List<SliderDto>>> GetList()
    {
        var result = await _facade.GetSliders();
        return QueryResult(result);
    }
    [HttpGet("{id}")]
    public async Task<ApiResult<SliderDto?>> GetById(long id)
    {
        var result = await _facade.GetSliderById(id);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> Create(CreateSliderCommand command)
    {
        var result = await _facade.CreateSlider(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit(EditSliderCommand command)
    {
        var result = await _facade.EditSlider(command);
        return CommandResult(result);
    }
}