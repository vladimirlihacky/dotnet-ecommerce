namespace Core.Domain;

public enum OperationType
{
    Debit, 
    Credit,
}

public class PaymentOperation
{
    public readonly Guid Id;
    public readonly Guid AccountId;
    public readonly OperationType Type;
    public readonly decimal Amount;
    public readonly DateTimeOffset Timestamp;

    public PaymentOperation(Guid id, Guid accountId, OperationType op, decimal amount, DateTimeOffset timestamp)
    {
        Id = id;
        AccountId = accountId;
        Type = op;
        Amount = amount;
        Timestamp = timestamp;

        Validate();
    }

    public void Validate()
    {
        if(Id == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("Id", Id);
        }
        if(AccountId == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("AccountId", AccountId);
        }
        if(Amount < 0)
        {
            throw new InvalidPropertyException<decimal>("Amount", Amount);
        }
    }
}