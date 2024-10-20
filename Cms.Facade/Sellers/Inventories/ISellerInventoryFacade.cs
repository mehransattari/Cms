using Common.Application;
using MediatR;
using Cms.Application.Sellers.AddInventory;
using Cms.Application.Sellers.EditInventory;

namespace Cms.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> AddInventory(EditSellerInventoryCommand command);
}

internal class SellerInventoryFacade : ISellerInventoryFacade
{
    private IMediator _mediator;

    public SellerInventoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }
}
