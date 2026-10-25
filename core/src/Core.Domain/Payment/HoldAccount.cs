using Core.Domain;

namespace core.Domain;

public class HoldAccount : Account
{
    new public readonly AccountType Type = AccountType.Hold; 
    public readonly Guid BaseAccountId;
    public HoldAccount(Guid id, Guid baseAccountId) : base(id)
    {
        BaseAccountId = baseAccountId;
    }
}