namespace Core.Domain;


public class Category
{
    public readonly Guid Id; 
    public string Name { get; private set; }
    public Guid? ParentCategoryId { get; private set; }
    public List<SearchAttribute> Attributes { get; private set; }

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
        Attributes = attributes;
    }

    public void Validate(
        Guid id, 
        string name, 
        Guid? parentCategoryId, 
        List<SearchAttribute> attributes
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid category id");
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Invalid category name");
        if(parentCategoryId == Guid.Empty)
            throw new ArgumentException("Invalid category parent id");
        if(attributes.Distinct().Count() != attributes.Count())
            throw new ArgumentException("Invalid category attributes");
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
        Attributes = attributes;
    }
}