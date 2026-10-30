namespace Core.Services.Models;


public record UserAuth
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Domain.UserAuthType Type { get; init; }
    public string Credentials { get; init; } = string.Empty;
    public User? User { get; set; }
}