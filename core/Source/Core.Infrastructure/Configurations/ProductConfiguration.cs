namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_Products_Cost_Discount",
            "[Cost] >= 0 AND [Discount] >= 0 AND [Discount] < 1"
        ));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(250);
        
        builder.Property(p => p.Cost)
            .HasPrecision(18, 2);
        
        builder.Property(p => p.Discount)
            .HasPrecision(18, 10);

        builder.HasMany(p => p.Attributes)
            .WithOne(pa => pa.Product)
            .HasForeignKey(pa => pa.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Thumbnails)
            .WithOne(t => t.Product)
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.WarehouseEntry)
            .WithOne(we => we.Product)
            .HasForeignKey<Product>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}