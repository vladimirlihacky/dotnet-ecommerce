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

public class SearchAttribute
{
    private SearchAttribute(){}
    public string Type { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;

    public SearchAttribute(string attrType, string name)
    {
        Validate(attrType, name);

        Type = attrType;
        Name = name;
    }

    public SearchAttribute(ProductAttribute productAttr)
        : this(productAttr.Type, productAttr.Name) { }

    private static void Validate(string attrType, string name)
    {
        if (string.IsNullOrEmpty(attrType))
            throw new ValidationException("Invalid attribute type");
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Invalid attribute name");
    }
}
