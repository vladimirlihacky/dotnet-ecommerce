namespace Core.Domain;


public class ShoppingCart
{
    public readonly Guid Id;
    public List<ShoppingCartEntry> Entries { get; private set; }

    public ShoppingCart(
        Guid id, 
        List<ShoppingCartEntry> entries
    )
    {
        Validate(id, entries);

        Id = id; 
        Entries = entries;
    }

    public void Validate(
        Guid id, 
        List<ShoppingCartEntry> entries
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid shopping cart id");
    }

    public void Update(List<ShoppingCartEntry> entries)
    {
        Validate(Id, entries);

        Entries = entries;
    }

    public void Clear()
    {
        Entries.Clear();
    }
}

