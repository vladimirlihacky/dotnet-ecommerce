namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class SearchAttributeConfiguration : IEntityTypeConfiguration<SearchAttribute>
{
    public void Configure(EntityTypeBuilder<SearchAttribute> builder)
    {
        builder.ToTable("SearchAttributes");

        builder.HasKey(sa => sa.Id);

        builder.HasOne(sa => sa.Category)
            .WithMany(c => c.Attributes)
            .HasForeignKey(sa => sa.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}