using Cms.Facade.Categories;
using Cms.Facade.Comments;
using Cms.Facade.Orders;
using Cms.Facade.Products;
using Cms.Facade.Roles;
using Cms.Facade.Sellers;
using Cms.Facade.Sellers.Inventories;
using Cms.Facade.Siteentities.Banner;
using Cms.Facade.Siteentities.Slider;
using Cms.Facade.Users;
using Cms.Facade.Users.Addresses;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<ISellerFacade, SellerFacade>();
        services.AddScoped<IBannerFacade, BannerFacade>();
        services.AddScoped<ISliderFacade, SliderFacade>();
        services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();

        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();

    }
}