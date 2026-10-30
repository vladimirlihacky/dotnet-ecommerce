namespace Core.Infrastructure.Models;


public class ShoppingCart
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public User? User { get; set; }
    public List<ShoppingCartEntry>? Entries { get; set; }
}

