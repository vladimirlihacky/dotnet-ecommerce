namespace Core.Domain;

/*
Не использую просто поле Quantity в Product, т.к в дальнейшем 
планирую сделать поддержку нескольких складов, т.е придется в WarehouseEntry
добавить WarehouseId.
*/

public class WarehouseEntry
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public WarehouseEntry(Guid id, Guid productId, int quantity)
    {
        Validate(id, productId, quantity);
        
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }

    private WarehouseEntry()
    {
    }

    private static void Validate(Guid id, Guid productId, int quantity)
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid warehouse entry id");
        if(productId == Guid.Empty)
            throw new ValidationException("Invalid warehouse entry product id");
        if(int.IsNegative(quantity))
            throw new ValidationException("Invalid warehouse entry quantity");
    }

    public void SetQuantity(int quantity)
    {
        Validate(Id, ProductId, quantity);

        Quantity = quantity;
    }
}