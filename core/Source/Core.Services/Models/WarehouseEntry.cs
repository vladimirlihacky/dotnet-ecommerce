namespace Core.Services.Models;

public record WarehouseEntry
{
    public Guid ProductId { get; init; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }
}