namespace Core.Infrastructure.Models;

public class WarehouseEntry
{
    public Guid ProductId { get; init; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }
}