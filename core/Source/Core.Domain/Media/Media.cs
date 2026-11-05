namespace Core.Domain;


public class Media
{
    public Guid Id { get; private set; }
    public string Path { get; private set; } = string.Empty;

    private Media(){}

    public Media(Guid id, string path)
    {
        Validate(id, path);

        Id = id;
        Path = path;
    }

    private static void Validate(Guid id, string path)
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid media id");
        if (string.IsNullOrEmpty(path))
            throw new ValidationException("Invalid media");
    }
}