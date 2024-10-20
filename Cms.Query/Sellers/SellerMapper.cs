using Cms.Query.Sellers.DTOs;
using Cms.Domain.SellerAgg;

namespace Cms.Query.Sellers;

public static class SellerMapper
{
    public static SellerDto Map(this Seller seller)
    {
        if (seller == null)
            return null;

        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            Status = seller.Status,
            NationalCode = seller.NationalCode,
            CmsName = seller.CmsName,
            UserId = seller.UserId
        };
    }
}