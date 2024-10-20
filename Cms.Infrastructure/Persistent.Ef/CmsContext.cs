using Microsoft.EntityFrameworkCore;
using Cms.Domain.CategoryAgg;
using Cms.Domain.CommentAgg;
using Cms.Domain.OrderAgg;
using Cms.Domain.ProductAgg;
using Cms.Domain.RoleAgg;
using Cms.Domain.SellerAgg;
using Cms.Domain.SiteEntities;
using Cms.Domain.UserAgg;

namespace Cms.Infrastructure.Persistent.Ef;

public class CmsContext : DbContext
{
    public CmsContext(DbContextOptions<CmsContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SellerInventory> Inventories { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}