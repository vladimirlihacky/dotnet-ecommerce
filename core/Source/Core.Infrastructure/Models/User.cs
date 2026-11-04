using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Models;

public class User : IdentityUser<Guid>
{
    public UserAccount? Account { get; set; }
    public UserProfile? Profile { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public List<UserAuth>? AuthProviders { get; set; }
    public List<Order>? Orders { get; set; }
}