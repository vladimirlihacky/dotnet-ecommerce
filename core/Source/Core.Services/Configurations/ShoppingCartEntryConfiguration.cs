namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class ShoppingCartEntryConfiguration : IEntityTypeConfiguration<ShoppingCartEntry>
{
    public void Configure(EntityTypeBuilder<ShoppingCartEntry> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_ShoppingCartEntries_Quantity",
            "[Quantity] > 0"
        ));

        builder.HasKey(sce => sce.Id);

        builder.HasOne(sce => sce.ShoppingCart)
            .WithMany(sc => sc.Entries)
            .HasForeignKey(sce => sce.ShoppingCartId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sce => sce.Product)
            .WithMany(p => p.ShoppingCartEntries)
            .HasForeignKey(sce => sce.ProductId);
    }
}