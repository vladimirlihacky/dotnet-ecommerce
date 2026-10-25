namespace Core.Domain;

public class ShoppingCart
{
    public Guid Id { get; private set; }
    public Dictionary<Guid, int> Products { get; } = new Dictionary<Guid, int>();

    public ShoppingCart(Guid id)
    {
        Id = id;

        Validate();
    }

    public void Validate()
    {
        if (Id == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("Id", Id);
        }

        ValidateProducts();
    }

    public void ValidateProducts()
    {
        foreach(var p in Products)
        {
            if(p.Value <= 0)
            {
                throw new InvalidPropertyException<int>($"Product {p.Key}", p.Value);
            }
        }
    }

    public void SetProductAmount(Guid product, int amount)
    {
        if(amount <= 0)
        {
            throw new InvalidPropertyException<int>($"Product {product}", amount);
        }

        Products[product] = amount;
    }

    public void RemoveProduct(Guid product)
    {
        Products.Remove(product);
    }
}