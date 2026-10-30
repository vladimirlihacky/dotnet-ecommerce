namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class LedgerEntryConfiguration : IEntityTypeConfiguration<LedgerEntry>
{
    public void Configure(EntityTypeBuilder<LedgerEntry> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_LedgerEntries_Amount",
            "[Amount] >= 0"
        ));

        builder.HasKey(le => le.Id);

        builder.HasOne(le => le.Account)
            .WithMany(a => a.LedgerEntries)
            .HasForeignKey(le => le.AccountId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(le => le.Amount)
            .HasPrecision(18, 2);
    }
}