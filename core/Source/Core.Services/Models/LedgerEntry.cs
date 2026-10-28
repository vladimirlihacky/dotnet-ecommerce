namespace Core.Services.Models;


public record LedgerEntry
{
    public required Guid Id;
    public required Guid AccountId;
    public required Domain.OperationType Operation; 
    public required decimal Amount;
    public required Domain.Currency Currency;
    public required DateTimeOffset Timestamp;

    public Account? Account; 
}