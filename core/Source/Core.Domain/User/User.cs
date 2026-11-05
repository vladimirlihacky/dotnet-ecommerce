namespace Core.Domain;


/*
Пока предполагаем, что профиль, счет и корзина у пользователя постоянные
*/

public class User
{
    public readonly Guid Id; 
    public readonly Guid AccountId; 
    public readonly Guid ProfileId; 
    public readonly Guid ShoppingCartId;
    public string Name { get; private set; }

    public User(
        Guid id, 
        Guid accountId, 
        Guid profileId, 
        Guid shoppingCartId, 
        string name
    )
    {
        Validate(
            id, 
            accountId,
            profileId,
            shoppingCartId,
            name
        );
        
        Id = id; 
        AccountId = accountId; 
        ProfileId = profileId; 
        ShoppingCartId = shoppingCartId; 
        Name = name;
    }

    public void SetName(string name)
    {
        if(string.IsNullOrEmpty(name))
        {
            throw new ValidationException("User name should be provided");
        }

        Name = name;
    }

    protected static void Validate(
        Guid id, 
        Guid accountId, 
        Guid profileId, 
        Guid shoppingCartId, 
        string name
    )
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid user id");
        if(accountId == Guid.Empty)
            throw new ValidationException("Invalid user account id");
        if(profileId == Guid.Empty)
            throw new ValidationException("Invalid user profile id");
        if(shoppingCartId == Guid.Empty)
            throw new ValidationException("Invalid user shopping cart id");
        if(string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid user name");
    }
}
