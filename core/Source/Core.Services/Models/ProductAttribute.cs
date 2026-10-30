namespace Core.Services.Models;

public class ProductAttribute
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public Guid SearchAttributeId { get; init; }
    public string Value { get; set; } = string.Empty;
    public SearchAttribute? SearchAttribute { get; set; }
    public Product? Product { get; set; }
}
