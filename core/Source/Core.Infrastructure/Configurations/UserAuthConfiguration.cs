namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class UserAuthConfiguration : IEntityTypeConfiguration<UserAuth>
{
    public void Configure(EntityTypeBuilder<UserAuth> builder)
    {
        builder.ToTable("UserAuthProviders");

        builder.HasKey(ua => ua.Id);

        builder.Property(ua => ua.Credentials)
            .IsRequired()
            .HasMaxLength(500);
    }
}