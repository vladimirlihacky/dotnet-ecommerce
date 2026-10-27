namespace Core.Domain;


/*
Пока оставляю атрибуты только в виде строки.
Атрибуты наследуются от ProductAttribute и определяют валидацию значения

Скажем какой-нибудь ColorSet.Validate()

public Validate() {
    List<string> colors = Value.Split(",");

    if(colors.Any(color => !AllowedColors.Contains(color.Trim())))
        throw new ValidationException("Invalid color");
}  

Скорее всего создам ProductAttributeRegistry, который уже будет создавать 
атрибуты корректного типа из ProductAttribute.Type;
*/

public record struct SearchAttribute
{
    public readonly string Type;
    public readonly string Name;

    public SearchAttribute(string attrType, string name)
    {
        Validate(attrType, name);

        Type = attrType;
        Name = name;
    }

    public SearchAttribute(ProductAttribute productAttr)
        : this(productAttr.Type, productAttr.Name) { }

    public void Validate(string attrType, string name)
    {
        if (string.IsNullOrEmpty(attrType))
            throw new ArgumentException("Invalid attribute type");
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Invalid attribute name");
    }
}

public record struct ProductAttribute
{
    public readonly string Type;
    public readonly string Name;
    public string Value { get; private set; }

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

    public void Validate(
        string attrType, 
        string name, 
        string value
    )
    {
        if (string.IsNullOrEmpty(attrType))
            throw new ArgumentException("Invalid attribute type");
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Invalid attribute name");
        ValidateValue(value);
    }

    public void SetValue(string value)
    {
        ValidateValue(value);

        Value = value;
    }

    public void ValidateValue(string value) { }
}