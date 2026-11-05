namespace Core.Domain;


public enum AccountType
{
    System,
    Hold,
    User,
}

public class Account
{
    public Guid Id { get; private set; }
    public AccountType Type { get; private set; }
    public Currency Currency { get; private set; }
    public decimal Balance { get; private set; }

    public Account(
        Guid id,
        AccountType accountType,
        Currency currency,
        decimal balance = 0
    )
    {
        Validate(
            id,
            accountType,
            currency,
            balance
        );

        Id = id;
        Type = accountType;
        Currency = currency;
        Balance = balance;

    }

    private Account()
    {
    }

    private static void Validate(
        Guid id,
        AccountType accountType,
        Currency currency,
        decimal balance = 0
    )
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid account id");
        if (decimal.IsNegative(balance))
            throw new ValidationException("Invalid balance");
    }

    public void Credit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ValidationException("Credit amount should be positive");
        }

        Balance = Balance + amount;
    }

    public void Debit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ValidationException("Debit amount should be positive");
        }
        if (Balance < amount)
        {
            throw new InvalidStateTransitionException("Account balance should be positive");
        }

        Balance = Balance - amount;
    }
}