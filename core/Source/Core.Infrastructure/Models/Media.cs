namespace Core.Infrastructure.Models;


public class Media
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Path { get; init; } = string.Empty;
    public Product? Product { get; set; }
}