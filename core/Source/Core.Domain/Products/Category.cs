namespace Core.Domain;


public class Category
{
    public Guid Id { get; private set; } 
    public string Name { get; private set; } = string.Empty;
    public Guid? ParentCategoryId { get; private set; }
    private List<SearchAttribute> _attributes { get; set; } = [];
    public IReadOnlyList<SearchAttribute> Attributes => _attributes;

    public Category(
        Guid id, 
        string name, 
        Guid? parentCategoryId, 
        List<SearchAttribute> attributes
    )
    {
        Validate(
            id, 
            name,
            parentCategoryId, 
            attributes
        );

        Id = id; 
        Name = name; 
        ParentCategoryId = parentCategoryId;
        _attributes = attributes;
    }

    private Category()
    {
    }

    private static void Validate(
        Guid id, 
        string name, 
        Guid? parentCategoryId, 
        List<SearchAttribute> attributes
    )
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid category id");
        if(string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid category name");
        if(parentCategoryId == Guid.Empty)
            throw new ValidationException("Invalid category parent id");
        if(attributes.DistinctBy(a => a.Name).Count() != attributes.Count())
            throw new ValidationException("Invalid category attributes");
    }

    public void Update(
        string name, 
        Guid? parentCategoryId, 
        List<SearchAttribute> attributes
    )
    {
        Validate(
            Id, 
            name,
            parentCategoryId, 
            attributes
        );

        Name = name; 
        ParentCategoryId = parentCategoryId;
        _attributes = attributes;
    }
}