using Cms.Query.Sellers.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Sellers.GetByFilter;

public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
{
    public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
    {
    }
}

public class SellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    private CmsContext _context;

    public SellerByFilterQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Sellers.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.NationalCode))
            result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

        if (!string.IsNullOrWhiteSpace(@params.CmsName))
            result = result.Where(r => r.CmsName.Contains(@params.CmsName));


        var skip = (@params.PageId - 1) * @params.Take;

        var sellerResult = new SellerFilterResult()
        {
            FilterParams = @params,
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(seller => seller.Map())
                .ToListAsync(cancellationToken)
        };

        sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
        return sellerResult;
    }
}