using Common.Application;
using MediatR;
using Cms.Application.Sellers.Create;
using Cms.Application.Sellers.Edit;
using Cms.Query.Sellers.DTOs;
using Cms.Query.Sellers.GetByFilter;
using Cms.Query.Sellers.GetById;

namespace Cms.Facade.Sellers;

internal class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<SellerDto?> GetSellerById(long sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));

    }
    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }
}