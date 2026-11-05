namespace Core.Domain;


public class ShoppingCartEntry
{
    public Guid Id { get; private set; }
    public Guid ShoppingCartId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

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

    private ShoppingCartEntry()
    {
    }

    public void SetQuantity(int quantity)
    {
        if(int.IsNegative(quantity))
        {
            throw new ValidationException("Invalid shopping cart entry amount");
        }

        Quantity = quantity;
    }

    private static void Validate(
        Guid id, 
        Guid shoppingCartId, 
        Guid productId, 
        int quantity
    )
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid shopping cart entry id");
        if(shoppingCartId == Guid.Empty)
            throw new ValidationException("Invalid shopping cart id");
        if(productId == Guid.Empty)
            throw new ValidationException("Invalid shopping cart entry product id");
        if(int.IsNegative(quantity))
            throw new ValidationException("Invalid shopping cart entry amount");
    }
}