﻿using Common.Application;
using Common.Domain.ValueObjects;

namespace Cms.Application.Categories.AddChild;

public record AddChildCategoryCommand(long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand<long>;