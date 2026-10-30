namespace Core.Services.Models; 


public abstract record Account
{
    public Guid Id { get; init; }
    public Guid OwnerId { get; init; }
    public Domain.AccountType Type { get; init; }
    public Domain.Currency Currency { get; init; }
    public decimal Balance { get; set; }
    public List<LedgerEntry>? LedgerEntries { get; set; }
}

public record SystemAccount : Account
{
}

public record UserAccount : Account
{
    public Guid? UserId { get; set; } 
    public User? User { get; set; }
}

public record HoldAccount : Account
{
    public Guid? BaseAccountId { get; set; } 
    public Account? BaseAccount { get; set; }
}