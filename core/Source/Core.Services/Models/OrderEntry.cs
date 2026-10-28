namespace Core.Services;


public record OrderEntry
{
    public required Guid Id;
    public required Guid ProductId;
    public required string Name;
    public required decimal Cost;
    public required decimal Discount;
    public required decimal DiscountedCost;
    public required int Quantity;

    public Product? Product;
}