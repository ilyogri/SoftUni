using ChameleonStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ChameleonStore.Data.EntityConfig
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                 .HasMany(b => b.Products)
                 .WithOne(p => p.Brand)
                 .HasForeignKey(p => p.BrandId);
        }
    }
}
