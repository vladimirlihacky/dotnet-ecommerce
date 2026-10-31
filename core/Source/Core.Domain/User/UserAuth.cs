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
    public readonly Guid Id; 
    public readonly Guid UserId; 
    public readonly UserAuthType Type;
    public readonly string Credentials;

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
        Credentials = credentials;
    }

    public void Validate(
        Guid id, 
        Guid userId, 
        UserAuthType authType,
        string credentials
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid auth id");
        if(userId == Guid.Empty)
            throw new ArgumentException("Invalid auth user id");
        if(string.IsNullOrEmpty(credentials))
            throw new ArgumentException("Invalid auth credentials");
    }
}