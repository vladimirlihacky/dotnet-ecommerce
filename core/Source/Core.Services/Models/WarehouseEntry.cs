namespace Core.Services.Models;

public record WarehouseEntry
{
    public required Guid ProductId;
    public required int Quantity;
}