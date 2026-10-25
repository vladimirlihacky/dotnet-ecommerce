namespace Core.Domain;

public class ShoppingCart
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Dictionary<Guid, int> Products { get; } = new Dictionary<Guid, int>();

    public ShoppingCart(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;

        Validate();
    }

    public ShoppingCart(
        Guid id,
        Guid userId,
        Dictionary<Guid, int> products
        )
    {
        Id = id;
        UserId = userId;
        Products = products;

        Validate();
    }

    public void Validate()
    {
        if (Id == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("Id", Id);
        }

        if (UserId == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("UserUd", UserId);
        }

        ValidateProducts();
    }

    public void ValidateProducts()
    {
        foreach (var p in Products)
        {
            if (p.Value <= 0)
            {
                throw new InvalidPropertyException<int>($"Product {p.Key}", p.Value);
            }
        }
    }

    public void SetProductAmount(Guid product, int amount)
    {
        if (amount < 0)
        {
            throw new InvalidPropertyException<int>($"Product {product}", amount);
        }
        if(amount == 0)
        {
            RemoveProduct(product);
            return;
        }

        Products[product] = amount;
    }

    public void RemoveProduct(Guid product)
    {
        Products.Remove(product);
    }

    public void Clear()
    {
        Products.Clear();
    }
}