using Cms.Query.Categories.DTOs;
using Common.Query;

namespace Cms.Query.Categories.GetById;

public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;