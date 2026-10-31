namespace Core.Domain;

/*
Не использую просто поле Quantity в Product, т.к в дальнейшем 
планирую сделать поддержку нескольких складов, т.е придется в WarehouseEntry
добавить WarehouseId.
*/

public record WarehouseEntry
{
    public readonly Guid ProductId;
    public int Quantity { get; private set; }

    public WarehouseEntry(Guid productId, int quantity)
    {
        Validate(productId, quantity);

        ProductId = productId;
        Quantity = quantity;
    } 

    public void Validate(Guid productId, int quantity)
    {
        if(productId == Guid.Empty)
            throw new ArgumentException("Invalid warehouse entry product id");
        if(int.IsNegative(quantity))
            throw new ArgumentException("Invalid warehouse entry quantity");
    }

    public void SetQuantity(int quantity)
    {
        Validate(ProductId, quantity);

        Quantity = quantity;
    }
}