namespace Core.Domain;

public struct Media(Guid id, string path)
{
    public readonly Guid Id = id;
    public readonly string Path = path; 
}