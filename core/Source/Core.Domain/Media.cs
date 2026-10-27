namespace Core.Domain;


public record Media
{
    public readonly Guid Id;
    public readonly string Path;

    public Media(Guid id, string path)
    {
        Validate(id, path);

        Id = id;
        Path = path;
    }

    public void Validate(Guid id, string path)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid media id");
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Invalid media");
    }
}