namespace Core.Tests;

using Core.Domain;

public class ProductTest
{
    [Fact]
    public void Create_Works()
    {
        Guid id = Guid.CreateVersion7(); 
        string name = "name"; 
        decimal cost = 123;
        
        Product product = new Product(id, name, cost);    
        Assert.Equal(id, product.Id);
        Assert.Equal(name, product.Name);
        Assert.Equal(cost, product.Cost);
    }

    [Fact]
    public void Update_Works()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 123);

        string name = "new name"; 
        decimal cost = 1234;
        
        product.Update(name, cost, product.Discount, product.Description, product.Category, product.Thumbnails);

        Assert.Equal(name, product.Name);
        Assert.Equal(cost, product.Cost);
    }

    [Fact]
    public void GetDiscountedCost_Works()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 100);
        product.SetDiscount(0.1m);
        Assert.Equal(90, product.DiscountedCost);
    }

    [Fact]
    public void Create_WithEmptyId_ThrowsInvalidPropertyException()
    {
        Assert.Throws<InvalidPropertyException<Guid>>(() => new Product(Guid.Empty, "name", 123));
    }

    [Fact]
    public void Create_WithEmptyName_ThrowsInvalidPropertyException()
    {
        Assert.Throws<InvalidPropertyException<string>>(() => new Product(Guid.CreateVersion7(), "", 123));
    }

    [Fact]
    public void Create_WithNegativeCost_ThrowsInvalidPropertyException()
    {
        Assert.Throws<InvalidPropertyException<decimal>>(() => new Product(Guid.CreateVersion7(), "name", -123));
    }

    [Fact]
    public void Set_EmptyName_ThrowsInvalidPropertyException()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 123);
        Assert.Throws<InvalidPropertyException<string>>(() => product.SetName(""));
    }

    [Fact]
    public void Set_NegativeCost_ThrowsInvalidPropertyException()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 123);
        Assert.Throws<InvalidPropertyException<decimal>>(() => product.SetCost(-1));
    }

    [Fact]
    public void Set_DiscountMoreThan1_ThrowsInvalidPropertyException()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 123);
        Assert.Throws<InvalidPropertyException<decimal>>(() => product.SetDiscount(1.5m));
    }

    [Fact]
    public void Set_NegativeDiscount_ThrowsInvalidPropertyException()
    {
        Product product = new Product(Guid.CreateVersion7(), "name", 123);
        Assert.Throws<InvalidPropertyException<decimal>>(() => product.SetDiscount(-1));
    }

}
