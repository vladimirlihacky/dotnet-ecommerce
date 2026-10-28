namespace Core.Services.Models;


public record ShoppingCart
{
    public required Guid Id;
    public required List<Guid> EntryIds;
    public required List<ShoppingCartEntry>? Entries;
}

