namespace Core.Services.Models;

public record ProductAttribute
{
    public Guid Id { get; set; }
    public Guid ProductId { get; init; }
    public Guid SearchAttributeId { get; init; }
    public string Value { get; set; } = string.Empty;
    public SearchAttribute? SearchAttribute { get; set; }
}
