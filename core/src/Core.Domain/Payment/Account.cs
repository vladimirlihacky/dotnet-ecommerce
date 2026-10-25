namespace Core.Domain;

public enum AccountType
{
    System, 
    Hold, 
    User,
}

public class Account
{
    public readonly AccountType Type = AccountType.System;
    public readonly Guid Id; 

    public decimal Balance { get; private set; }

    public Account(Guid id)
    {
        Id = id; 
        Balance = 0;
    }

    public void Debit(decimal amount)
    {
        if(amount < 0)
        {
            throw new InvalidValueException("Debit amount should be positive");
        }
        if(amount > Balance)
        {
            throw new InvalidOperationException("Debit amount bigger than balance");
        }

        Balance = Balance - amount;
    }

    public void Credit(decimal amount)
    {
        if(amount < 0)
        {
            throw new InvalidValueException("Credit amount should be positive");
        }
        
        Balance = Balance + amount;
    }
}