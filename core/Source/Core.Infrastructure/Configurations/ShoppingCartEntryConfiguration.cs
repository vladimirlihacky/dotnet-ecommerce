namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class ShoppingCartEntryConfiguration : IEntityTypeConfiguration<ShoppingCartEntry>
{
    public void Configure(EntityTypeBuilder<ShoppingCartEntry> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_ShoppingCartEntries_Quantity",
            "[Quantity] > 0"
        ));

        builder.HasKey(sce => sce.Id);

        builder.HasOne(sce => sce.Product)
            .WithMany(p => p.ShoppingCartEntries)
            .HasForeignKey(sce => sce.ProductId);
        
        builder.HasIndex(sce => new{ sce.ProductId, sce.ShoppingCartId })
            .IsUnique()
            .HasDatabaseName("IX_ShoppingCartEntry_ShoppingCartId_ProductId_Unique");
    }
}