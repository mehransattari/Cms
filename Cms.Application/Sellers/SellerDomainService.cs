using Cms.Domain.SellerAgg;
using Cms.Domain.SellerAgg.Repository;
using Cms.Domain.SellerAgg.Services;

namespace Cms.Application.Sellers;

public class SellerDomainService : ISellerDomainService
{
    private readonly ISellerRepository _sellerRepository;
    public SellerDomainService(ISellerRepository sellerRepository)
    {
         _sellerRepository  = sellerRepository;
    }

    public bool IsValidSellerInformation(Seller seller)
    {
        var sellerExist = _sellerRepository.Exists(x => x.NationalCode == seller.NationalCode ||
                                                        x.UserId == seller.UserId);

        return sellerExist;
    }

    public bool NationalCodeExistInDataBase(string nationalCode)
    {
        throw new NotImplementedException();
    }
}