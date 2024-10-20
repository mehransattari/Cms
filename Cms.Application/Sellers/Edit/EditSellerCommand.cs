using Common.Application;
using Cms.Domain.SellerAgg;

namespace Cms.Application.Sellers.Edit;

public record EditSellerCommand(long Id, string CmsName, string NationalCode, SellerStatus Status) : IBaseCommand;