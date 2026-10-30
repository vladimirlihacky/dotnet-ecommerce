namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes");

        builder.HasKey(pa => pa.Id);

        builder.Property(pa => pa.Value)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasOne(pa => pa.SearchAttribute)
            .WithMany()
            .HasForeignKey(pa => pa.SearchAttributeId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasIndex(pa => new{ pa.ProductId, pa.SearchAttributeId })
            .IsUnique()
            .HasDatabaseName("IX_ProductAttribute_ProductId_SearchAttributeId_Unique");
    }
}