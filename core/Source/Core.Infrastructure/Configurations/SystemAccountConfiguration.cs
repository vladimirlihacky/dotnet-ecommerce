namespace Core.Infrastructure.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Models;

public class SystemAccountConfiguration : IEntityTypeConfiguration<SystemAccount>
{
    public void Configure(EntityTypeBuilder<SystemAccount> builder)
    {
        builder.ToTable("Accounts");
    }
}