namespace Core.Services.Models;


public class Product
{
    public Guid Id { get; init; } 
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public decimal Discount { get; set; }
    public Category? Category { get; set; }
    public List<Media>? Thumbnails { get; set; }
    public List<ProductAttribute>? Attributes { get; set; }
    public WarehouseEntry? WarehouseEntry { get; set; }
    public List<OrderEntry>? OrderEntries { get; set; }
    public List<ShoppingCartEntry>? ShoppingCartEntries { get; set; }
}