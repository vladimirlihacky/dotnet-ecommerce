namespace Core.Domain;


public enum OperationType
{
    Debit,
    Credit,
}

public class LedgerEntry
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public OperationType Operation { get; private set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }

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

    private LedgerEntry()
    {
    }

    private static void Validate(
        Guid id,
        Guid accountId,
        OperationType operation,
        decimal amount,
        Currency currency,
        DateTimeOffset timestamp
    )
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid ledger entry id");
        if (accountId == Guid.Empty)
            throw new ValidationException("Invalid ledger entry account id");
        if (decimal.IsNegative(amount))
            throw new ValidationException("Invalid ledger entry amount");
    }
}