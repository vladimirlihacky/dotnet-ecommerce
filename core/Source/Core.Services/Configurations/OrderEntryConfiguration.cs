namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class OrderEntryConfiguration : IEntityTypeConfiguration<OrderEntry>
{
    public void Configure(EntityTypeBuilder<OrderEntry> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_Order_Quantity_Cost",
            "[Quantity] > 0 AND [Cost] >= 0"
        ));

        builder.HasKey(oe => oe.Id);

        builder.HasOne(oe => oe.Product)
            .WithMany(p => p.OrderEntries)
            .HasForeignKey(oe => oe.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(oe => oe.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(oe => oe.Cost)
            .HasPrecision(18, 2);

        builder.Property(oe => oe.Discount)
            .HasPrecision(18, 2);
        
        builder.Property(oe => oe.DiscountedCost)
            .HasPrecision(18, 2);
    }
}