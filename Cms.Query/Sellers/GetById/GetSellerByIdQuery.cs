using Cms.Query.Sellers.DTOs;
using Common.Query;

namespace Cms.Query.Sellers.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; private set; }
}