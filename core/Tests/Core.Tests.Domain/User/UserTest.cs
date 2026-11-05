namespace Core.Tests.Domain;

using Core.Domain;

public class UserTest
{
    private Guid userId = Guid.CreateVersion7();
    private Guid invalidId = Guid.Empty;

    [Fact]
    public void CreateUserWorks()
    {
        User user = new User(userId);

        Assert.Equal(userId, user.Id);
    }

    [Fact]
    public void UserValidationWorks()
    {
        Assert.Throws<ValidationException>(() =>
        {
            User user = new User(invalidId);
        });
    }
}
