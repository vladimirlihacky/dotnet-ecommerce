namespace Core.Domain;

public record ShoppingCartEntry(Guid productId, int amount)
{
    public Guid ProductId = productId;
    public int Amount = amount; 
}
public class ShoppingCart
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Dictionary<Guid, ShoppingCartEntry> Products { get; }

    public ShoppingCart(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
        Products = new Dictionary<Guid, ShoppingCartEntry>();
        
        Validate();
    }

    public ShoppingCart(
        Guid id,
        Guid userId,
        Dictionary<Guid, ShoppingCartEntry> products
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

    // TODO: вынести валидацию отдельного продукта в ShoppingCartEntry
    public void ValidateProducts()
    {
        foreach (var p in Products)
        {
            ShoppingCartEntry entry = p.Value;

            if (entry.ProductId == Guid.Empty)
            {
                throw new InvalidPropertyException<Guid>($"Entry.ProductId", entry.ProductId);
            }
            if (entry.Amount <= 0)
            {
                throw new InvalidPropertyException<int>($"Entry.Amount", entry.Amount);
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

        Products[product] = new ShoppingCartEntry(product, amount);
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