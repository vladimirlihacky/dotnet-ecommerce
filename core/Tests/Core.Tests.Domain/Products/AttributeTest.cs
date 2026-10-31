namespace Core.Tests.Domain;

using Core.Domain;

public class SearchAttributeTest {
    private string attrType = "type";
    private string name = "name";
    private string invalidAttrType = "";
    private string invalidName = "";

    [Fact]
    public void CreateSearchAttributeWorks()
    {
        SearchAttribute attribute = new SearchAttribute(attrType, name);

        Assert.Equal(attrType, attribute.Type);
        Assert.Equal(name, attribute.Name);
    }

    [Fact]
    public void CreateSearchAttributeFromProductAttributeWorks()
    {
        ProductAttribute productAttribute = new ProductAttribute(attrType, name, "anyvalue");
        SearchAttribute attribute = new SearchAttribute(productAttribute);

        Assert.Equal(attrType, attribute.Type);
        Assert.Equal(name, attribute.Name);
    }

    [Fact]
    public void SearchAttributeValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new SearchAttribute(invalidAttrType, name);
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new SearchAttribute(attrType, invalidName);
        });
    }
}

public class ProductAttributeTest {
    private string attrType = "type";
    private string name = "name";
    private string value = "value";
    private string invalidAttrType = "";
    private string invalidName = "";

    [Fact]
    public void CreateProductAttributeWorks()
    {
        ProductAttribute attribute = new ProductAttribute(attrType, name, value);

        Assert.Equal(attrType, attribute.Type);
        Assert.Equal(name, attribute.Name);
        Assert.Equal(value, attribute.Value);
    }

    [Fact]
    public void CreateProductAttributeFromSearchAttributeWorks()
    {
        SearchAttribute searchAttribute = new SearchAttribute(attrType, name);
        ProductAttribute attribute = new ProductAttribute(searchAttribute, value);

        Assert.Equal(attrType, attribute.Type);
        Assert.Equal(name, attribute.Name);
        Assert.Equal(value, attribute.Value);
    }

    [Fact]
    public void ProductAttributeValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new ProductAttribute(invalidAttrType, name, value);
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new ProductAttribute(attrType, invalidName, value);
        });
    }

    [Fact]
    public void ProductAttributeSetValueWorks()
    {
        ProductAttribute attribute = new ProductAttribute(attrType, name, value);
        string newValue = "newvalue";

        attribute.SetValue(newValue);

        Assert.Equal(newValue, attribute.Value);
    }
}