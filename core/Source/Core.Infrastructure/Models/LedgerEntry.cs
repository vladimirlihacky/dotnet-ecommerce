namespace Core.Infrastructure.Models;


public class LedgerEntry
{
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public Domain.OperationType Operation { get; init; } 
    public decimal Amount { get; init; }
    public Domain.Currency Currency { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    public Account? Account { get; init; } 
}