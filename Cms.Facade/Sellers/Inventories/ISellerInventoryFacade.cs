using Common.Application;
using Cms.Application.Sellers.AddInventory;
using Cms.Application.Sellers.EditInventory;

namespace Cms.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
}
