namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(b => b.HasCheckConstraint(
            "CK_Accounts_Balance",
            "[Balance] >= 0"
        ));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Type)
            .HasConversion<string>();

        builder.HasDiscriminator(a => a.Type)
            .HasValue<SystemAccount>(Domain.AccountType.System)
            .HasValue<UserAccount>(Domain.AccountType.User)
            .HasValue<HoldAccount>(Domain.AccountType.Hold);

        builder.HasMany(a => a.LedgerEntries)
            .WithOne(le => le.Account)
            .HasForeignKey(le => le.AccountId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(a => a.Balance)
            .HasPrecision(18, 2);
    }
}