using Common.Query;
using Common.Query.Filter;
using Cms.Domain.SellerAgg;

namespace Cms.Query.Sellers.DTOs;

public class SellerDto : BaseDto
{
    public long UserId { get; set; }
    public string CmsName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}

public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParams>
{

}

public class SellerFilterParams : BaseFilterParam
{
    public string CmsName { get; set; }
    public string NationalCode { get; set; }
}