namespace Core.Services;

public record ProductAttribute
{
    public required string Type;
    public required string Name;
    public required string Value = "";
}
