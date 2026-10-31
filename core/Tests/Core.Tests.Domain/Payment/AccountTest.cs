namespace Core.Tests.Domain;

using Core.Domain;

public class AccountTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid ownerId = Guid.CreateVersion7();
    private AccountType accountType = AccountType.System;
    private Currency currency = Currency.RUB;
    private decimal balance = 100;
    private Guid invalidId = Guid.Empty;
    private decimal invalidBalance = -1;

    [Fact]
    public void CreateAccountWorks()
    {
        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );

        Assert.Equal(id, account.Id);
        Assert.Equal(ownerId, account.OwnerId);
        Assert.Equal(accountType, account.Type);
        Assert.Equal(currency, account.Currency);
        Assert.Equal(balance, account.Balance);
    }

    [Fact]
    public void AccountValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Account(
                invalidId,
                ownerId,
                accountType,
                currency,
                balance
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Account(
                id,
                invalidId,
                accountType,
                currency,
                balance
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Account(
                id,
                ownerId,
                accountType,
                currency,
                invalidBalance
            );
        });
    }

    [Fact]
    public void AccountCreditWorks()
    {
        decimal balance = 1000;
        decimal amount = 100; 
        
        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );
        
        account.Credit(amount);

        Assert.Equal(balance + amount, account.Balance);
    }

    [Fact]
    public void AccountCreditThrowsOnNegativeAmount()
    {
        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );
        
        decimal negativeAmount = -1; 

        Assert.Throws<ArgumentException>(() => account.Credit(negativeAmount));
    }

    [Fact]
    public void AccountDebitWorks()
    {
        decimal balance = 1000;
        decimal amount = 100; 
        
        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );
        
        account.Debit(amount);

        Assert.Equal(balance - amount, account.Balance);
    }

    [Fact]
    public void AccountDebitThrowsOnNegativeAmount()
    {
        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );
        
        decimal negativeAmount = -1; 

        Assert.Throws<ArgumentException>(() => account.Debit(negativeAmount));
    }

    [Fact]
    public void AccountDebitThrowsOnAmountMoreThanBalance()
    {
        decimal balance = 100;
        decimal amount = 1000;

        Account account = new Account(
            id,
            ownerId,
            accountType,
            currency,
            balance
        );

        Assert.Throws<InvalidOperationException>(() => account.Debit(amount));
    }
}