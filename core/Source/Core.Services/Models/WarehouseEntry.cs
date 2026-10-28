namespace Core.Services;

public record WarehouseEntry
{
    public required Guid ProductId;
    public required int Quantity;
}