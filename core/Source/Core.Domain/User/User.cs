namespace Core.Domain;


public class User
{
    public Guid Id { get; private set; }

    public User(Guid id)
    {
        Validate(id);

        Id = id;
    }

    private User()
    {
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ValidationException("User name should be provided");
        }
    }

    private static void Validate(Guid id)
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid user id");
    }
}
