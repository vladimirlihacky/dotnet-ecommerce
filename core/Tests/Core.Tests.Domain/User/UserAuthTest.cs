namespace Core.Tests.Domain;

using Core.Domain;

public class UserAuthTest
{
    private Guid id = Guid.CreateVersion7(); 
    private Guid userId = Guid.CreateVersion7();
    private string credentials = "credentials";
    private UserAuthType authType = UserAuthType.EmailPassword;
    private Guid invalidId = Guid.Empty;
    private string invalidCredentials = "";

    [Fact]
    public void CreateUserAuthWorks()
    {
        UserAuth userAuth = new UserAuth(
            id, 
            userId, 
            authType,
            credentials
        );

        Assert.Equal(id, userAuth.Id);
        Assert.Equal(userId, userAuth.UserId);
        Assert.Equal(authType, userAuth.Type);
        Assert.Equal(credentials, userAuth.Credentials);
    }

    [Fact]
    public void UserAuthValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            UserAuth userAuth = new UserAuth(
                invalidId,
                userId,
                authType,
                credentials
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            UserAuth userAuth = new UserAuth(
                id,
                invalidId,
                authType,
                credentials
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            UserAuth userAuth = new UserAuth(
                id,
                userId,
                authType,
                invalidCredentials
            );
        });
    }
}