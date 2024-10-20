using Cms.Infrastructure._Utilities;
using Cms.Infrastructure.Persistent.Ef;
using Cms.Domain.ProductAgg;
using Cms.Domain.ProductAgg.Repository;

namespace Cms.Infrastructure.Persistent.Ef.ProductAgg;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(CmsContext context) : base(context)
    {
    }
}