using Common.Application;
using Cms.Domain.CategoryAgg;
using Cms.Domain.CategoryAgg.Services;

namespace Cms.Application.Categories.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainServicer;

    public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer)
    {
        _repository = repository;
        _domainServicer = domainServicer;
    }

    public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Title, request.Slug, request.SeoData, _domainServicer);
        _repository.Add(category);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);
    }

}