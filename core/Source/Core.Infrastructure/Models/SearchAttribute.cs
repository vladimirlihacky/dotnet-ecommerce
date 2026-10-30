namespace Core.Infrastructure.Models;

public class SearchAttribute
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; init; }
    public string Type { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Category? Category { get; set; }
}