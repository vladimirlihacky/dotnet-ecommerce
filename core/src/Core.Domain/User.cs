namespace Core.Domain
{
    public enum UserRole
    {
        User,
        Admin,
    }
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public UserRole Role { get; private set; }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
            Role = Role;
        }

        public void Validate()
        {
            if (Id == Guid.Empty)
            {
                throw new InvalidPropertyException<Guid>("Id", Id);
            }

            if (Name == "")
            {
                throw new InvalidPropertyException<string>("Name", Name);
            }
        }

        public void SetRole(UserRole role)
        {
            Role = role;
        }
    }
}
