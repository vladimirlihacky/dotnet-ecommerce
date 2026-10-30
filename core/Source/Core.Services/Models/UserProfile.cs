namespace Core.Services.Models;

public class UserProfile
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public User? User { get; set; }
}