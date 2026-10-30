namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class UserAuthConfiguration : IEntityTypeConfiguration<UserAuth>
{
    public void Configure(EntityTypeBuilder<UserAuth> builder)
    {
        builder.ToTable("UserAuthProviders");

        builder.HasKey(ua => ua.Id);

        builder.Property(ua => ua.Credentials)
            .IsRequired();

        builder.HasOne(ua => ua.User)
            .WithMany(u => u.AuthProviders)
            .HasForeignKey(ua => ua.UserId) 
            .OnDelete(DeleteBehavior.NoAction);
    }
}