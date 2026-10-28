namespace Core.Services;


public record ShoppingCartEntry
{
    public required Guid Id;
    public required Guid ShoppingCartId;
    public required Guid ProductId;
    public required int Quantity;
    public ShoppingCart? ShoppingCart;
    public Product? Product;
}