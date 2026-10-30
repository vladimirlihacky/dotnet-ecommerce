namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class OrderEntryConfiguration : IEntityTypeConfiguration<OrderEntry>
{
    public void Configure(EntityTypeBuilder<OrderEntry> builder)
    {
        builder.ToTable("OrderEntries");

        builder.HasKey(oe => oe.Id);

        builder.HasOne(oe => oe.Order)
            .WithMany(o => o.Entries)
            .HasForeignKey(oe => oe.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(oe => oe.Product)
            .WithMany(p => p.OrderEntries)
            .HasForeignKey(oe => oe.ProductId);
        
        builder.Property(oe => oe.Cost)
            .HasPrecision(18, 2);

        builder.Property(oe => oe.Discount)
            .HasPrecision(18, 2);
        
        builder.Property(oe => oe.DiscountedCost)
            .HasPrecision(18, 2);
    }
}