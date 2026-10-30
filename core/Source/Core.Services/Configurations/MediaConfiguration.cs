namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("ProductThumbnails");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Path)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasIndex(m => m.Path)
            .IsUnique()
            .HasDatabaseName("IX_Media_Path");
    }
}