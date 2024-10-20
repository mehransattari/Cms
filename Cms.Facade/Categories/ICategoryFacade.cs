using Common.Application;
using Cms.Application.Categories.AddChild;
using Cms.Application.Categories.Create;
using Cms.Application.Categories.Edit;
using Cms.Query.Categories.DTOs;

namespace Cms.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult<long>> Edit(EditCategoryCommand command);
    Task<OperationResult<long>> Create(CreateCategoryCommand command);
    Task<OperationResult> Remove(long categoryId);

    Task<CategoryDto> GetCategoryById(long id);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
    Task<List<CategoryDto>> GetCategories();

}