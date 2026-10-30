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
            .HasDatabaseName("IX_Users_Name_Unique");

        builder.HasOne(u => u.Account)
            .WithOne(a => a.User)
            .HasForeignKey<UserAccount>(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.ShoppingCart)
            .WithOne(c => c.User)
            .HasForeignKey<ShoppingCart>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.AuthProviders)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
           .WithOne(o => o.User)
           .HasForeignKey(o => o.UserId)
           .OnDelete(DeleteBehavior.NoAction);
    }
}