namespace Core.Domain;


public record OrderEntry
{
    public readonly Guid Id;
    public readonly Guid ProductId;
    public readonly string Name;
    public readonly decimal Cost;
    public readonly decimal Discount;
    public readonly decimal DiscountedCost;
    public readonly int Quantity;

    public OrderEntry(
        Guid id,
        Guid productId,
        string name,
        decimal cost,
        decimal discount,
        decimal discountedCost,
        int quantity
    )
    {
        Validate(
            id,
            productId,
            name,
            cost,
            discount,
            discountedCost,
            quantity
        );

        Id = id; 
        ProductId = productId;
        Name = name; 
        Cost = cost; 
        Discount = discount;
        DiscountedCost = discountedCost;
        Quantity = quantity;
    }

    public void Validate(
        Guid id,
        Guid productId,
        string name,
        decimal cost,
        decimal discount,
        decimal discountedCost,
        int quantity
    )
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid order entry id");
        if (productId == Guid.Empty)
            throw new ArgumentException("Invalid order entry product id");
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Invalid order entry name");
        if(decimal.IsNegative(cost))
            throw new ArgumentException("Invalid order entry cost");
        if(decimal.IsNegative(discount) || discount > 1)
            throw new ArgumentException("Invalid order entry discount");
        if(decimal.IsNegative(discountedCost))
            throw new ArgumentException("Invalid order entry discounted cost");
        if(int.IsNegative(quantity))
            throw new ArgumentException("Invalid order entry quantity");
    }
}