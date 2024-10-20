﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cms.Domain.SiteEntities;

namespace Cms.Infrastructure.Persistent.Ef.SiteEntities
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(b => b.ImageName)
                     .HasMaxLength(120).IsRequired();

            builder.Property(b => b.Title)
                    .HasMaxLength(120);

            builder.Property(b => b.Link)
                .HasMaxLength(500);
        }
    }
}