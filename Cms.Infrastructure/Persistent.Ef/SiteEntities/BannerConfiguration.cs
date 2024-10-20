﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cms.Domain.SiteEntities;

namespace Cms.Infrastructure.Persistent.Ef.SiteEntities;
internal class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Link)
            .HasMaxLength(500).IsRequired();
    }
}