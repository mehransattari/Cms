﻿using Cms.Application.SiteEntities.Banners.Create;
using Cms.Application.SiteEntities.Banners.Edit;
using Cms.Facade.Siteentities.Banner;
using Cms.Query.SiteEntities.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class BannerController : ApiController
{
    private readonly IBannerFacade _facade;
    public BannerController(IBannerFacade facade)
    {
        _facade = facade;
    }
    [HttpGet]
    public async Task<ApiResult<List<BannerDto>>> GetList()
    {
        var result = await _facade.GetBanners();
        return QueryResult(result);
    }
    [HttpGet("{id}")]
    public async Task<ApiResult<BannerDto?>> GetById(long id)
    {
        var result = await _facade.GetBannerById(id);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> Create(CreateBannerCommand command)
    {
        var result = await _facade.CreateBanner(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit(EditBannerCommand command)
    {
        var result = await _facade.EditBanner(command);
        return CommandResult(result);
    }
}