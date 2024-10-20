using Common.Application;
using MediatR;
using Cms.Application.Categories.AddChild;
using Cms.Application.Categories.Create;
using Cms.Application.Categories.Edit;
using Cms.Query.Categories.DTOs;
using Cms.Query.Categories.GetById;
using Cms.Query.Categories.GetByParentId;
using Cms.Query.Categories.GetList;
using Cms.Application.Categories.Remove;

namespace Cms.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;

    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> Remove(long categoryId)
    {
        return await _mediator.Send(new RemoveCategoryCommand(categoryId));
    }

    public async Task<CategoryDto> GetCategoryById(long id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(id));
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));

    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryListQuery());
    }
}