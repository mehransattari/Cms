﻿using Common.Query;

namespace Cms.Query.Products.DTOs;

public class ProductImageDto : BaseDto
{
    public long ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}