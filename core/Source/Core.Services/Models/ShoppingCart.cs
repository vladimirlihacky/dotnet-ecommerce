namespace Core.Services.Models;


public record ShoppingCart
{
    public Guid Id;
    public Guid UserId;
    public List<Guid> EntryIds = [];
    public User? User;
    public List<ShoppingCartEntry>? Entries;
}

