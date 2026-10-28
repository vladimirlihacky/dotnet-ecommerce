namespace Core.Services.Models;


public record UserAuth
{
    public required Guid Id; 
    public required Guid UserId; 
    public required Domain.UserAuthType Type;
    public required string Credentials;
    public User? User;
}