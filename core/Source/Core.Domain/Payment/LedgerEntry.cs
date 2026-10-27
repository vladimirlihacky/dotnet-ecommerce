namespace Core.Domain;


public enum OperationType
{
    Debit,
    Credit,
}

public record LedgerEntry
{
    public readonly Guid Id;
    public readonly Guid AccountId;
    public readonly OperationType Operation; 
    public readonly decimal Amount;
    public readonly Currency Currency;
    public readonly DateTimeOffset Timestamp;

    public LedgerEntry(
        Guid id, 
        Guid accountId, 
        OperationType operation, 
        decimal amount,
        Currency currency, 
        DateTimeOffset timestamp
    )
    {
        Validate(
            id,
            accountId,
            operation,
            amount,
            currency,
            timestamp
        );

        Id = id; 
        AccountId = accountId;
        Operation = operation;
        Amount = amount; 
        Currency = currency;
        Timestamp = timestamp;
    }

    public void Validate(
        Guid id, 
        Guid accountId, 
        OperationType operation, 
        decimal amount,
        Currency currency, 
        DateTimeOffset timestamp
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid ledger entry id");
        if(accountId == Guid.Empty)
            throw new ArgumentException("Invalid ledger entry account id");
        if(decimal.IsNegative(amount))
            throw new ArgumentException("Invalid ledger entry amount");
    }
}