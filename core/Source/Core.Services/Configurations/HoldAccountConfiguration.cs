namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class HoldAccountConfiguration : IEntityTypeConfiguration<HoldAccount>
{
    public void Configure(EntityTypeBuilder<HoldAccount> builder)
    {
        builder.ToTable("Accounts");
        builder.HasOne(ha => ha.BaseAccount)
            .WithOne()
            .HasForeignKey<HoldAccount>(ha => ha.BaseAccountId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}