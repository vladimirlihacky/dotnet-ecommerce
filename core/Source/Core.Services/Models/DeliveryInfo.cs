namespace Core.Services.Models;


public class DeliveryInfo
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public string Address { get; set; } = string.Empty;
    public Order? Order { get; set; }
}