using Common.Application;

namespace Cms.Application.Sellers.Create;

public class CreateSellerCommand : IBaseCommand
{
    public CreateSellerCommand(long userId, string CmsName, string nationalCode)
    {
        UserId = userId;
        CmsName = CmsName;
        NationalCode = nationalCode;
    }
    public long UserId { get; private set; }
    public string CmsName { get; private set; }
    public string NationalCode { get; private set; }
}