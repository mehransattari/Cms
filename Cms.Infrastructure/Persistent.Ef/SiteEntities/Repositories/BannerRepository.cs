﻿using Cms.Infrastructure._Utilities;
using Cms.Infrastructure.Persistent.Ef;
using Cms.Domain.SiteEntities;
using Cms.Domain.SiteEntities.Repositories;

namespace Cms.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(CmsContext context) : base(context)
        {
        }
    }
}