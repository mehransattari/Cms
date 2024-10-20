using Common.Application;
using Cms.Application.Sellers.Create;
using Cms.Application.Sellers.Edit;
using Cms.Query.Sellers.DTOs;

namespace Cms.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);

    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
}