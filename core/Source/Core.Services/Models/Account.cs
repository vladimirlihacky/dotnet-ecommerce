namespace Core.Services.Models; 


public record Account
{
    public required Guid Id; 
    public required Guid OwnerId;
    public required Domain.AccountType Type;
    public required Domain.Currency Currency;
    public required decimal Balance;
}