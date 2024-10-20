using Cms.Query.Sellers.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private CmsContext _CmsContext;

    public GetSellerByIdQueryHandler(CmsContext CmsContext)
    {
        _CmsContext = CmsContext;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _CmsContext.Sellers.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        return seller.Map();
    }
}