using Common.Application;
using Cms.Domain.SellerAgg;
using Cms.Domain.SellerAgg.Repository;
using Cms.Domain.SellerAgg.Services;

namespace Cms.Application.Sellers.Create;

internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;
    public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.UserId, request.CmsName, request.NationalCode, _domainService);

        _repository.Add(seller);
        await _repository.Save();

        return OperationResult.Success();
    }
}