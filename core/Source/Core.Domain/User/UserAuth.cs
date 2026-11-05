namespace Core.Domain;


/*
UserAuth.Credentials - JSON/JSONB/etc строка, которую парсит конкретный провайдер.

Скажем EmailPassword:

{ "email": "example@mail.com", "passwordHash": "..." }

Или OAuth2.0

{ "client_id": "...", "client_secret": "...", ... }

Пока из типов будет только по email + password. 
*/

public enum UserAuthType
{
    EmailPassword,
}

public class UserAuth
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public UserAuthType Type { get; private set; }
    public string Claim { get; private set; } = string.Empty;

    public UserAuth(
        Guid id,
        Guid userId,
        UserAuthType authType,
        string credentials
    )
    {
        Validate(id, userId, authType, credentials);

        Id = id;
        UserId = userId;
        Type = authType;
        Claim = credentials;
    }

    private UserAuth()
    {
    }

    private static void Validate(
        Guid id,
        Guid userId,
        UserAuthType authType,
        string credentials
    )
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid auth id");
        if (userId == Guid.Empty)
            throw new ValidationException("Invalid auth user id");
        if (string.IsNullOrEmpty(credentials))
            throw new ValidationException("Invalid auth credentials");
    }
}