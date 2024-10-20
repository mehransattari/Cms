using Cms.Query.Categories.DTOs;
using Common.Query;

namespace Cms.Query.Categories.GetList;

public record GetCategoryListQuery : IQuery<List<CategoryDto>>;