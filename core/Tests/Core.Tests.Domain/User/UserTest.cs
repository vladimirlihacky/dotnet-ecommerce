namespace Core.Tests.Domain;

using Core.Domain;

public class UserTest
{
    private Guid userId = Guid.CreateVersion7();
    private Guid accountId = Guid.CreateVersion7();
    private Guid profileId = Guid.CreateVersion7();
    private Guid shoppingCartId = Guid.CreateVersion7();
    private string name = "correctUsername";
    private Guid invalidId = Guid.Empty;
    private string invalidName = "";

    [Fact]
    public void CreateUserWorks()
    {
        User user = new User(
            userId,
            accountId,
            profileId,
            shoppingCartId,
            name
        );

        Assert.Equal(userId, user.Id);
        Assert.Equal(accountId, user.AccountId);
        Assert.Equal(profileId, user.ProfileId);
        Assert.Equal(shoppingCartId, user.ShoppingCartId);
        Assert.Equal(name, user.Name);
    }

    [Fact]
    public void UserValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            User user = new User(
                invalidId,
                accountId,
                profileId,
                shoppingCartId,
                name
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            User user = new User(
                userId,
                invalidId,
                profileId,
                shoppingCartId,
                name
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            User user = new User(
                userId,
                accountId,
                invalidId,
                shoppingCartId,
                name
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            User user = new User(
                userId,
                accountId,
                profileId,
                invalidId,
                name
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            User user = new User(
                userId,
                accountId,
                profileId,
                shoppingCartId,
                invalidName
            );
        });
    }

    [Fact]
    public void UserSetNameWorks()
    {
        User user = new User(
            userId,
            accountId,
            profileId,
            shoppingCartId,
            name
        );
        
        Assert.Equal(name, user.Name);

        string newName = "newName";
        
        user.SetName("newName");

        Assert.Equal(newName, user.Name);
        
        Assert.Throws<ArgumentException>(() => user.SetName(""));
    }
}
