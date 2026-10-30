namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(u => u.Name)
            .IsUnique()
            .HasDatabaseName("IX_Users_Name");

        builder.HasOne(u => u.Account)
            .WithOne()
            .HasForeignKey<User>(u => u.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.ShoppingCart)
            .WithOne(sc => sc.User)
            .HasForeignKey<User>(u => u.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.AuthProviders)
            .WithOne(ua => ua.User)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
           .WithOne(ua => ua.User)
           .HasForeignKey(ua => ua.UserId)
           .OnDelete(DeleteBehavior.NoAction);
    }
}