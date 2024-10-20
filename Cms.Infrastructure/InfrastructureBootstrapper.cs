using Cms.Infrastructure.Persistent.Ef;
using Cms.Infrastructure.Persistent.Ef.CategoryAgg;
using Cms.Infrastructure.Persistent.Ef.CommentAgg;
using Cms.Infrastructure.Persistent.Ef.OrderAgg;
using Cms.Infrastructure.Persistent.Ef.ProductAgg;
using Cms.Infrastructure.Persistent.Ef.RoleAgg;
using Cms.Infrastructure.Persistent.Ef.SellerAgg;
using Cms.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Cms.Infrastructure.Persistent.Ef.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cms.Domain.CategoryAgg;
using Cms.Domain.CommentAgg;
using Cms.Domain.OrderAgg.Repository;
using Cms.Domain.ProductAgg.Repository;
using Cms.Domain.RoleAgg.Repository;
using Cms.Domain.SellerAgg.Repository;
using Cms.Domain.SiteEntities.Repositories;
using Cms.Domain.UserAgg.Repository;
using Cms.Infrastructure.Persistent.Dapper;

namespace Cms.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();


            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<CmsContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}