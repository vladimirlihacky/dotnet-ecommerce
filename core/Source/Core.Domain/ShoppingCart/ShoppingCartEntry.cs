namespace Core.Domain;


public record ShoppingCartEntry
{
    public readonly Guid Id;
    public readonly Guid ShoppingCartId;
    public readonly Guid ProductId;
    public readonly int Quantity;

    public ShoppingCartEntry(
        Guid id, 
        Guid shoppingCartId, 
        Guid productId, 
        int quantity
    )
    {
        Validate(
            id,
            shoppingCartId,
            productId,
            quantity
        );

        Id = id; 
        ShoppingCartId = shoppingCartId;
        ProductId = productId;
        Quantity = quantity;
    }

    public void Validate(
        Guid id, 
        Guid shoppingCartId, 
        Guid productId, 
        int quantity
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid shopping cart entry id");
        if(shoppingCartId == Guid.Empty)
            throw new ArgumentException("Invalid shopping cart id");
        if(productId == Guid.Empty)
            throw new ArgumentException("Invalid shopping cart entry product id");
        if(int.IsNegative(quantity))
            throw new ArgumentException("Invalid shopping cart entry amount");
    }
}