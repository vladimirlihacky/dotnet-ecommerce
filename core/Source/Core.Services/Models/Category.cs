namespace Core.Services.Models;


public record Category
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public Guid? ParentCategoryId { get; set; }
    public List<Guid> AttributeIds { get; set; } = [];

    public Category? ParentCategory { get; set; }
    public List<SearchAttribute>? Attributes { get; set; }
    public List<Product>? Products { get; set; }
}