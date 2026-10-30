namespace Core.Services.Models;


public record OrderStatusHistoryEntry
{
    public Guid Id { get; init; } 
    public Guid OrderId { get; init; }
    public Domain.OrderStatus FromStatus { get; init; } 
    public Domain.OrderStatus ToStatus { get; init; }
    public string Cause { get; init; } = string.Empty;
    public DateTimeOffset Timestamp { get; init; }
    public Order? Order { get; init; }
}