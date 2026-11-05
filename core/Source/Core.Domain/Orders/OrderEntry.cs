namespace Core.Domain;


public class OrderEntry
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Cost { get; private set; }
    public decimal Discount { get; private set; }
    public decimal DiscountedCost { get; private set; }
    public int Quantity { get; private set; }

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

    private OrderEntry()
    {
    }

    private static void Validate(
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
            throw new ValidationException("Invalid order entry id");
        if (productId == Guid.Empty)
            throw new ValidationException("Invalid order entry product id");
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid order entry name");
        if (decimal.IsNegative(cost))
            throw new ValidationException("Invalid order entry cost");
        if (decimal.IsNegative(discount) || discount > 1)
            throw new ValidationException("Invalid order entry discount");
        if (decimal.IsNegative(discountedCost))
            throw new ValidationException("Invalid order entry discounted cost");
        if (int.IsNegative(quantity))
            throw new ValidationException("Invalid order entry quantity");
    }
}