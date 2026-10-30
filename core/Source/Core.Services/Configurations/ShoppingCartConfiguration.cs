namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCarts");

        builder.HasKey(sc => sc.Id);

        builder.HasOne(sc => sc.User)
            .WithOne(u => u.ShoppingCart)
            .HasForeignKey<User>(u => u.ShoppingCartId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(sc => sc.Entries)
            .WithOne(sce => sce.ShoppingCart)
            .HasForeignKey(sce => sce.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}