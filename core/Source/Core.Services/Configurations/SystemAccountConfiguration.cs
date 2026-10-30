namespace Core.Services.ModelConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Services.Models;

public class SystemAccountConfiguration : IEntityTypeConfiguration<SystemAccount>
{
    public void Configure(EntityTypeBuilder<SystemAccount> builder)
    {
        builder.ToTable("Accounts");
    }
}