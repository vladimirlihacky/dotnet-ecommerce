namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class OrderStatusHistoryEntryConfiguration : IEntityTypeConfiguration<OrderStatusHistoryEntry>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistoryEntry> builder)
    {
        builder.ToTable("OrderStatusHistoryEntries");

        builder.HasKey(she => she.Id);

        builder.HasOne(she => she.Order)
            .WithMany(o => o.StatusHistory)
            .HasForeignKey(oe => oe.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}