namespace Core.Infrastructure.Models;


public class Order
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Domain.OrderStatus Status { get; set; }
    public User? User { get; set; }
    public DeliveryInfo? Delivery { get; set; }
    public List<OrderEntry>? Entries { get; set; }
    public List<OrderStatusHistoryEntry> StatusHistory { get; set; } = [];
}