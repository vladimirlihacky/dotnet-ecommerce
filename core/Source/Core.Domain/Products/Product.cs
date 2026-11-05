namespace Core.Domain;


public class Product
{
    public Guid Id { get; private set; } 
    public Guid CategoryId { get; private set; } 
    public string Name { get; private set; } = string.Empty;
    public decimal Cost { get; private set; }
    public decimal Discount { get; private set; }
    public decimal DiscountedCost => Cost * (1 - Discount);
    private List<Media> _thumbnails { get; set; } = [];
    public IReadOnlyList<Media> Thumbnails => _thumbnails;
    private List<ProductAttribute> _attributes { get; set; } = [];
    public IReadOnlyList<ProductAttribute> Attributes => _attributes;
    
    public Product(
        Guid id, 
        Guid categoryId, 
        string name, 
        decimal cost,
        decimal discount, 
        List<Media> thumbnails, 
        List<ProductAttribute> attributes
    )
    {
        Validate(
            id, 
            categoryId, 
            name,
            cost,
            discount,
            thumbnails,
            attributes
        );

        Id = id; 
        CategoryId = categoryId; 
        Name = name;
        Cost = cost; 
        Discount = discount; 
        _thumbnails = thumbnails;
        _attributes = attributes;
    }

    private Product()
    {
    }

    private static void Validate(
        Guid id, 
        Guid categoryId, 
        string name, 
        decimal cost,
        decimal discount, 
        List<Media> thumbnails, 
        List<ProductAttribute> attributes
    )
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid product id");
        if(categoryId == Guid.Empty)
            throw new ValidationException("Invalid product category id");
        if(string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid product name");
        if(decimal.IsNegative(cost))
            throw new ValidationException("Invalid product cost");
        if(decimal.IsNegative(discount) || discount > 1)
            throw new ValidationException("Invalid product discount");
        if(attributes.DistinctBy(a => a.Name).Count() != attributes.Count())
            throw new ValidationException("Duplicate product attributes");
    }

    public void Update(
        Guid categoryId, 
        string name, 
        decimal cost,
        decimal discount, 
        List<Media> thumbnails, 
        List<ProductAttribute> attributes
    )
    {
        Validate(
            Id, 
            categoryId, 
            name,
            cost,
            discount,
            thumbnails,
            attributes
        );

        CategoryId = categoryId; 
        Name = name;
        Cost = cost; 
        Discount = discount; 
        _thumbnails = thumbnails;
        _attributes = attributes;
    }
}