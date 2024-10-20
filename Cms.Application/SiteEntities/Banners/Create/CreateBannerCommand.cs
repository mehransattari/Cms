﻿using Common.Application;
using Microsoft.AspNetCore.Http;
using Cms.Domain.SiteEntities;

namespace Cms.Application.SiteEntities.Banners.Create;

public class CreateBannerCommand : IBaseCommand
{
    public CreateBannerCommand(string link, IFormFile imageFile, BannerPosition position)
    {
        Link = link;
        ImageFile = imageFile;
        Position = position;
    }
    public string Link { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public BannerPosition Position { get; private set; }
}