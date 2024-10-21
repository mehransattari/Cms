using Cms.Application._Utilities;
using Cms.Application.Categories;
using Cms.Application.Products;
using Cms.Application.Roles.Create;
using Cms.Application.Sellers;
using Cms.Application.Users;
using Cms.Domain.CategoryAgg.Services;
using Cms.Domain.ProductAgg.Services;
using Cms.Domain.SellerAgg.Services;
using Cms.Domain.UserAgg.Services;
using Cms.Facade;
using Cms.Infrastructure;
using Cms.Query.Categories.GetById;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Config;

public static class CmsBootstrapper
{
    public static void RegisterShopDependency(this IServiceCollection services,string connectionString)
    {
        InfrastructureBootstrapper.Init(services,connectionString);

        services.AddMediatR(typeof(Directories).Assembly);

        services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();


        services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

        services.InitFacadeDependency();
    }
}