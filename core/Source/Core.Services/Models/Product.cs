namespace Core.Services.Models;


public record Product
{
    public required Guid Id; 
    public required Guid CategoryId;
    public required string Name;
    public required decimal Cost;
    public required decimal Discount;
    public required List<Guid> ThumbnailIds;
    public required List<ProductAttribute> Attributes;
    public Category? Category;
    public List<Media>? Thumbnails;
}