namespace Core.Tests;

using Core.Domain;

public class UserTest
{
    [Fact]
    public void Create_WithEmptyId_ThrowsInvalidPropertyException()
    {
        Assert.Throws<InvalidPropertyException<Guid>>(() => new User(Guid.Empty, "name"));
    }

    [Fact]
    public void Create_WithEmptyName_ThrowsInvalidPropertyException()
    {
        Assert.Throws<InvalidPropertyException<string>>(() => new User(Guid.CreateVersion7(), ""));
    }

    [Fact]
    public void SetRole_Works()
    {
        User user = new User(Guid.CreateVersion7(), "name");

        user.SetRole(UserRole.Admin);

        Assert.Equal(UserRole.Admin, user.Role);

        user.SetRole(UserRole.User);

        Assert.Equal(UserRole.User, user.Role);
    }
}
