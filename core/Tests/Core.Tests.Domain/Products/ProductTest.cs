namespace Core.Tests.Domain;

using Core.Domain;

public class ProductTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid categoryId = Guid.CreateVersion7();
    private string name = "name";
    private decimal cost = 100; 
    private decimal discount = 0.3m;
    private List<Media> thumbnails = [];
    private List<ProductAttribute> attributes = []; 
    private Guid invalidId = Guid.Empty;
    private string invalidName = "";
    private decimal invalidCost = -1;
    private decimal negativeDiscount = -1;
    private decimal tooBigDiscount = 1.25m;
    private List<ProductAttribute> duplicateAttributes = [
        new ProductAttribute("type", "name", "value"),
        new ProductAttribute("type", "name", "value"),
    ]; 


    [Fact]
    public void CreateProductWorks()
    {
        Product product = new Product(
            id,
            categoryId,
            name,
            cost,
            discount,
            thumbnails,
            attributes
        );

        Assert.Equal(id, product.Id);
        Assert.Equal(categoryId, product.CategoryId);
        Assert.Equal(name, product.Name);
        Assert.Equal(cost, product.Cost);
        Assert.Equal(discount, product.Discount);
        Assert.Equal(thumbnails, product.Thumbnails);
        Assert.Equal(attributes, product.Attributes);
    }    

    [Fact]
    public void ProductValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                invalidId, 
                categoryId,
                name,
                cost,
                discount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                invalidId,
                name,
                cost,
                discount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                invalidName,
                cost,
                discount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                name,
                invalidCost,
                discount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                name,
                cost,
                negativeDiscount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                name,
                cost,
                tooBigDiscount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                name,
                cost,
                tooBigDiscount,
                thumbnails,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                id, 
                categoryId,
                name,
                cost,
                discount,
                thumbnails,
                duplicateAttributes
            );
        });
    }

    [Fact]
    public void ProductDiscountedCostCorrect()
    {
        decimal cost = 100;
        decimal discount = 0.3m;
        decimal discountedCost = 70;

        Product product = new Product(
            id,
            categoryId,
            name,
            cost,
            discount,
            thumbnails,
            attributes
        );   

        Assert.Equal(discountedCost, product.DiscountedCost);
    }

    [Fact]
    public void ProductUpdateWorks()
    {
        Product product = new Product(
            id,
            categoryId,
            name,
            cost,
            discount,
            thumbnails,
            attributes
        );

        Guid updatedCategoryId = Guid.CreateVersion7();
        string updatedName = "updatedName";
        decimal updatedCost = 123;
        decimal updatedDiscount = 0; 
        List<Media> updatedThumbnails = [];
        List<ProductAttribute> updatedAttributes = [];

        product.Update(
            updatedCategoryId,
            updatedName,
            updatedCost,
            updatedDiscount,
            updatedThumbnails,
            updatedAttributes
        );

        Assert.Equal(updatedCategoryId, product.CategoryId);
        Assert.Equal(updatedName, product.Name);
        Assert.Equal(updatedCost, product.Cost);
        Assert.Equal(updatedDiscount, product.Discount);
        Assert.Equal(updatedThumbnails, product.Thumbnails);
        Assert.Equal(updatedAttributes, product.Attributes);
    }
}