namespace Core.Tests.Domain;

using Core.Domain;

public class CategoryTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid parentCategoryId = Guid.CreateVersion7();
    private string name = "name";
    private List<SearchAttribute> attributes = [];
    private Guid invalidId = Guid.Empty;
    private string invalidName = "";
    private List<SearchAttribute> duplicateAttributes = [
        new SearchAttribute("type", "name"),
        new SearchAttribute("type", "name"),
    ];

    [Fact]
    public void CreateCategoryWorks()
    {
        Category category = new Category(
            id,
            name,
            parentCategoryId,
            attributes
        );

        Assert.Equal(id, category.Id);
        Assert.Equal(name, category.Name);
        Assert.Equal(parentCategoryId, category.ParentCategoryId);
        Assert.Equal(attributes, category.Attributes);
    }

    [Fact]
    public void CategoryValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Category(
                invalidId,
                name,
                parentCategoryId,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Category(
                id,
                invalidName,
                parentCategoryId,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Category(
                id,
                name,
                invalidId,
                attributes
            );
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new Category(
                id,
                name,
                parentCategoryId,
                duplicateAttributes
            );
        });
    }

    [Fact]
    public void CategoryUpdateWorks()
    {
        Category category = new Category(
           id,
           name,
           parentCategoryId,
           attributes
       );

        string updatedName = "updatedname";
        Guid updatedParentCategoryId = Guid.CreateVersion7();
        List<SearchAttribute> updatedAttributes = [];

        category.Update(
            updatedName,
            updatedParentCategoryId,
            updatedAttributes
        );

        Assert.Equal(updatedName, category.Name);
        Assert.Equal(updatedParentCategoryId, category.ParentCategoryId);
        Assert.Equal(updatedAttributes, category.Attributes);
    }
}