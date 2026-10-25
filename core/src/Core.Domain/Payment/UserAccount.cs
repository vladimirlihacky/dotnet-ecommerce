using Core.Domain;

namespace core.Domain;

public class UserAccount : Account
{
    new public readonly AccountType Type = AccountType.User; 
    public readonly Guid UserId;
    public UserAccount(Guid id, Guid userId) : base(id)
    {
        UserId = userId;
    }
}