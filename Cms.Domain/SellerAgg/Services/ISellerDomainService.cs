using Cms.Domain.SellerAgg;

namespace Cms.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool IsValidSellerInformation(Seller seller);
    bool NationalCodeExistInDataBase(string nationalCode);
}