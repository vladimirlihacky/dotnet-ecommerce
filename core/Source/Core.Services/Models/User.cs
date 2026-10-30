namespace Core.Services.Models;

public record User
{
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public Guid ProfileId { get; init; }
    public Guid ShoppingCartId { get; init; }

    public string Name { get; init; } = string.Empty;

    public UserAccount? Account { get; set; }
    public UserProfile? Profile { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public List<UserAuth>? AuthProviders { get; set; }
    public List<Order>? Orders { get; set; }
}