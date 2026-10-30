namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class WarehouseEntryConfiguration : IEntityTypeConfiguration<WarehouseEntry>
{
    public void Configure(EntityTypeBuilder<WarehouseEntry> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_WarehouseEntries_Quantity",
            "[Quantity] >= 0"
        ));

        builder.HasKey(we => we.ProductId);

        builder.Property(we => we.Quantity)
            .IsRequired()
            .HasDefaultValue(0);
    }
}