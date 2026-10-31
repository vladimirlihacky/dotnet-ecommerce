namespace Core.Infrastructure.Models; 


public abstract class Account
{
    public Guid Id { get; init; }
    public Domain.AccountType Type { get; }
    public Domain.Currency Currency { get; init; }
    public decimal Balance { get; set; }
    public List<LedgerEntry>? LedgerEntries { get; set; }
}

public class SystemAccount : Account
{
}

public class UserAccount : Account
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
}

public class HoldAccount : Account
{
    public Guid? BaseAccountId { get; set; } 
    public UserAccount? BaseAccount { get; set; }
}