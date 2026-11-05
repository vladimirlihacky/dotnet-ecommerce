namespace Core.Domain;

public class ProductAttribute
{
    private ProductAttribute() { }
    public string Type { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;

    public ProductAttribute(
        string attrType,
        string name,
        string value
    )
    {
        Validate(attrType, name, value);

        Type = attrType;
        Name = name;
        Value = value;
    }

    public ProductAttribute(SearchAttribute searchAttr, string value)
        : this(searchAttr.Type, searchAttr.Name, value) { }


    private static void Validate(
        string attrType,
        string name,
        string value
    )
    {
        if (string.IsNullOrEmpty(attrType))
            throw new ValidationException("Invalid attribute type");
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid attribute name");
        ValidateValue(value);
    }

    public void SetValue(string value)
    {
        ValidateValue(value);

        Value = value;
    }

    private static void ValidateValue(string value) { }
}