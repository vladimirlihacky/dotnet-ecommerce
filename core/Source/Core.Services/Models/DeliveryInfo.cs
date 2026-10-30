namespace Core.Services.Models;


public record DeliveryInfo
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public string Address { get; set; } = string.Empty;
    public Order? Order { get; set; }
}