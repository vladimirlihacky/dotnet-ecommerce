namespace Core.Domain; 


public enum AccountType
{
    System, 
    Hold, 
    User,
}

public class Account
{
    public readonly Guid Id; 
    public readonly Guid OwnerId;
    public readonly AccountType Type;
    public readonly Currency Currency;
    public decimal Balance { get; private set; }

    public Account(
        Guid id, 
        Guid ownerId, 
        AccountType accountType, 
        Currency currency,
        decimal balance = 0
    )
    {
        Validate(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );

        Id = id; 
        OwnerId = ownerId; 
        Type = accountType; 
        Currency = currency;
        Balance = balance;

    }

    public void Validate(
        Guid id, 
        Guid ownerId, 
        AccountType accountType, 
        Currency currency,
        decimal balance = 0
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid account id");
        if(ownerId == Guid.Empty)
            throw new ArgumentException("Invalid account owner id");
        if(decimal.IsNegative(balance))
            throw new ArgumentException("Invalid balance");
    }

    public void Credit(decimal amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Credit amount should be positive");
        }

        Balance = Balance + amount;
    }

    public void Debit(decimal amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Debit amount should be positive");
        }
        if(Balance < amount)
        {
            throw new InvalidOperationException("Account balance should be positive");
        }

        Balance = Balance - amount;
    }
}