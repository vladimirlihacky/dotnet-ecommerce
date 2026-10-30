namespace Core.Services.Models;


public record OrderEntry
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public Guid OrderId { get; init; }
    public string Name { get; init; }
    public decimal Cost { get; init; }
    public decimal Discount { get; init; }
    public decimal DiscountedCost { get; init; }
    public int Quantity { get; init; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}