namespace Core.Domain;


public class ShoppingCart
{
    private ShoppingCart(){}
    public Guid Id { get; private set; }
    private List<ShoppingCartEntry> _entries { get; set; } = [];
    public IReadOnlyList<ShoppingCartEntry> Entries => _entries;

    public ShoppingCart(
        Guid id, 
        List<ShoppingCartEntry> entries
    )
    {
        Validate(id, entries);

        Id = id; 
        _entries = entries;
    }

    private static void Validate(
        Guid id, 
        List<ShoppingCartEntry> entries
    )
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid shopping cart id");
    }

    public void Update(List<ShoppingCartEntry> entries)
    {
        Validate(Id, entries);

        _entries = entries;
    }

    public void Clear()
    {
        _entries.Clear();
    }
}

