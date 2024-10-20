using Common.Application;
using Cms.Domain.SellerAgg.Repository;
using Cms.Domain.SellerAgg.Services;

namespace Cms.Application.Sellers.Edit;

internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;
    public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.Id);
        if (seller == null)
            return OperationResult.NotFound();

        seller.Edit(request.CmsName, request.NationalCode, request.Status, _domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}