namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class SearchAttributeConfiguration : IEntityTypeConfiguration<SearchAttribute>
{
    public void Configure(EntityTypeBuilder<SearchAttribute> builder)
    {
        builder.ToTable("SearchAttributes");

        builder.HasKey(sa => sa.Id);
        
        builder.Property(sa => sa.Name)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(sa => sa.Type)
            .IsRequired()
            .HasMaxLength(150);
    }
}