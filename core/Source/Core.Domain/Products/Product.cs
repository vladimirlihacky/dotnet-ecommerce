namespace Core.Domain;


public class Product
{
    public readonly Guid Id; 
    public Guid CategoryId { get; private set; } 
    public string Name { get; private set; }
    public decimal Cost { get; private set; }
    public decimal Discount { get; private set; }
    public decimal DiscountedCost => Cost * (1 - Discount);
    public List<Media> Thumbnails { get; private set; }
    public List<ProductAttribute> Attributes { get; private set; }
    
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
        Thumbnails = thumbnails;
        Attributes = attributes;
    }

    public void Validate(
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
            throw new ArgumentException("Invalid product id");
        if(categoryId == Guid.Empty)
            throw new ArgumentException("Invalid product category id");
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Invalid product name");
        if(decimal.IsNegative(cost))
            throw new ArgumentException("Invalid product cost");
        if(decimal.IsNegative(discount) || Discount > 1)
            throw new ArgumentException("Invalid product discount");
        if(attributes.Distinct().Count() != attributes.Count())
            throw new ArgumentException("Duplicate product attributes");
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
        Thumbnails = thumbnails;
        Attributes = attributes;
    }
}