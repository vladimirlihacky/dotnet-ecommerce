namespace Core.Services.Models;


public class ShoppingCartEntry
{
    public Guid Id { get; init; }
    public Guid ShoppingCartId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public Product? Product { get; set; }
}