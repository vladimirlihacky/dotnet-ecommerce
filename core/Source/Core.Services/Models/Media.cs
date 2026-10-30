namespace Core.Services.Models;


public record Media
{
    public required Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Path { get; init; } = string.Empty;
}