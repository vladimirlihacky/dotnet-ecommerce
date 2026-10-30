namespace Core.Services;

using Microsoft.EntityFrameworkCore;
using Core.Services.Models;

public class AppDbContext : DbContext
{
    public DbSet<Media> Media => Set<Media>();
    public DbSet<DeliveryInfo> DeliveryInfo => Set<DeliveryInfo>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderEntry> OrderEntries => Set<OrderEntry>();
    public DbSet<OrderStatusHistoryEntry> OrderStatusHistoryEntries => Set<OrderStatusHistoryEntry>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<SystemAccount> SystemAccounts => Set<SystemAccount>();
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();
    public DbSet<HoldAccount> HoldAccounts => Set<HoldAccount>();
    public DbSet<LedgerEntry> LedgerEntries => Set<LedgerEntry>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<SearchAttribute> SearchAttributes => Set<SearchAttribute>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
    public DbSet<ShoppingCartEntry> ShoppingCartEntries => Set<ShoppingCartEntry>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserAuth> UserAuthentications => Set<UserAuth>();
    public DbSet<WarehouseEntry> WarehouseEntries => Set<WarehouseEntry>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}