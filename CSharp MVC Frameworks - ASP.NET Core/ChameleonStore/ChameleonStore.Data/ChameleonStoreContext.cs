namespace ChameleonStore.Web.Data
{
    using ChameleonStore.Data.EntityConfig;
    using ChameleonStore.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ChameleonStoreContext : IdentityDbContext<User>
    {
        public ChameleonStoreContext(DbContextOptions<ChameleonStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new BrandConfig());
            base.OnModelCreating(builder);
        }
    }
}
