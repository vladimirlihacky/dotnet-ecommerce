namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class OrderStatusHistoryEntryConfiguration : IEntityTypeConfiguration<OrderStatusHistoryEntry>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistoryEntry> builder)
    {
        builder.ToTable("OrderStatusHistoryEntries");

        builder.HasKey(she => she.Id);

        builder.Property(she => she.Cause)
            .IsRequired()
            .HasMaxLength(250);
    }
}