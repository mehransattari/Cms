using Cms.Domain.CategoryAgg;
using Cms.Domain.CategoryAgg.Services;

namespace Cms.Application.Categories;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryDomainService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public bool IsSlugExist(string slug)
    {
        var result = _categoryRepository.Exists(x => x.Slug == slug);
        return result;
    }
}