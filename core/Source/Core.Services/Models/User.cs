namespace Core.Services.Models;


public record User
{
    public required Guid Id; 
    public required Guid AccountId; 
    public required Guid ProfileId; 
    public required Guid ShoppingCartId;
    public required string Name;
    public Account? Account;
    public UserProfile? Profile;
    public ShoppingCart? ShoppingCart;
}
