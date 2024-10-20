using Cms.Query.Categories.DTOs;
using Common.Query;

namespace Cms.Query.Categories.GetByParentId;

public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<ChildCategoryDto>>;