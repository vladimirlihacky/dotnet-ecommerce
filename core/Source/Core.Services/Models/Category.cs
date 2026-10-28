namespace Core.Services;


public record Category
{
    public required Guid Id; 
    public required string Name;
    public required Guid? ParentCategoryId;
    public required List<Guid> AttributeIds;

    public Category? ParentCategory;
    public List<SearchAttribute>? Attributes;
}