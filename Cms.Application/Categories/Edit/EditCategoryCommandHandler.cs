using Common.Application;
using Cms.Domain.CategoryAgg;
using Cms.Domain.CategoryAgg.Services;

namespace Cms.Application.Categories.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand,long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainServicer;

    public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer)
    {
        _repository = repository;
        _domainServicer = domainServicer;
    }

    public async Task<OperationResult<long>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.Id);
        if (category == null)
            return OperationResult<long>.NotFound();

        category.Edit(request.Title, request.Slug, request.SeoData, _domainServicer);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);
    }
}