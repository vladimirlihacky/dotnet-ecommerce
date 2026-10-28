namespace Core.Services.Models;


public record Order
{
    public required Guid Id;
    public required Guid UserId;
    public required Domain.OrderStatus Status;
    public required Guid DeliveryId;
    public required List<Guid> EntryIds;

    public User? User; 
    public DeliveryInfo? Delivery;
    public List<OrderEntry>? Entries;
}