namespace Core.Services;


public record OrderStatusHistoryEntry
{
    public required Guid Id; 
    public required Guid OrderId; 
    public required Domain.OrderStatus FromStatus; 
    public required Domain.OrderStatus ToStatus;
    public required string Cause; 
    public required DateTimeOffset Timestamp;
    public Order? Order; 
}