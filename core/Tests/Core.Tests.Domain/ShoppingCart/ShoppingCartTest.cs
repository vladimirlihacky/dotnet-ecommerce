namespace Core.Tests.Domain;

using Core.Domain;

public class ShoppingCartTest
{
    private Guid id = Guid.CreateVersion7();
    private List<ShoppingCartEntry> entries = [];
    private Guid invalidId = Guid.Empty;

    [Fact]
    public void CreateShoppingCartWorks()
    {
        ShoppingCart shoppingCart = new ShoppingCart(
            id,
            entries
        );

        Assert.Equal(id, shoppingCart.Id);
        Assert.Equal(entries, shoppingCart.Entries);
    }

    [Fact]
    public void ShoppingCartValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ShoppingCart shoppingCart = new ShoppingCart(
                invalidId,
                entries
            );
        });
    }

    [Fact]
    public void ShoppingCartUpdateWorks()
    {
        ShoppingCart shoppingCart = new ShoppingCart(
            id,
            entries
        );

        List<ShoppingCartEntry> newEntries = [new ShoppingCartEntry(id, id, id, 1)];

        shoppingCart.Update(newEntries);

        Assert.Equal(newEntries, shoppingCart.Entries);
    }

    [Fact]
    public void ShoppingCartClearWorks()
    {
        ShoppingCart shoppingCart = new ShoppingCart(
            id,
            [new ShoppingCartEntry(id, id, id, 1)]
        );

        shoppingCart.Clear();

        Assert.Empty(shoppingCart.Entries);
    }
}