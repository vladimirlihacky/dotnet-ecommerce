namespace Core.Tests.Domain;

using Core.Domain;

public class LedgerEntryTest
{
    private Guid id = Guid.CreateVersion7(); 
    private Guid accountId = Guid.CreateVersion7();
    private OperationType operation = OperationType.Debit;
    private decimal amount = 100;
    private Currency currency = Currency.RUB;
    private DateTimeOffset timestamp = DateTimeOffset.UtcNow;
    private Guid invalidId = Guid.Empty;
    private decimal invalidAmount = -100;

    [Fact]
    public void CreateLedgerEntryWorks()
    {
        LedgerEntry entry = new LedgerEntry(
            id,
            accountId,
            operation,
            amount,
            currency,
            timestamp
        );

        Assert.Equal(id, entry.Id);
        Assert.Equal(accountId, entry.AccountId);
        Assert.Equal(operation, entry.Operation);
        Assert.Equal(amount, entry.Amount);
        Assert.Equal(currency, entry.Currency);
        Assert.Equal(timestamp, entry.Timestamp);
    }

    [Fact]
    public void LedgerEntryValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new LedgerEntry(
                invalidId,
                accountId,
                operation,
                amount,
                currency,
                timestamp
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new LedgerEntry(
                id,
                invalidId,
                operation,
                amount,
                currency,
                timestamp
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new LedgerEntry(
                id,
                accountId,
                operation,
                invalidAmount,
                currency,
                timestamp
            );
        });
        
    }
}