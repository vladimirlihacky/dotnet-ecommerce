namespace Core.Tests.Domain;

using Core.Domain;

public class ShoppingCartEntryTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid shoppingCartId = Guid.CreateVersion7();
    private Guid productId = Guid.CreateVersion7();
    private int quantity = 10;
    private Guid invalidId = Guid.Empty;
    private int invalidQuantity = -1;


    [Fact]
    public void CreateShoppingCartEntryWorks()
    {
        ShoppingCartEntry entry = new ShoppingCartEntry(
            id,
            shoppingCartId,
            productId,
            quantity
        );

        Assert.Equal(id, entry.Id);
        Assert.Equal(shoppingCartId, entry.ShoppingCartId);
        Assert.Equal(productId, entry.ProductId);
        Assert.Equal(quantity, entry.Quantity);
    }

    [Fact]
    public void ShoppingCartEntryValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ShoppingCartEntry entry = new ShoppingCartEntry(
                invalidId,
                shoppingCartId,
                productId,
                quantity
            );
        });
        
        Assert.Throws<ArgumentException>(() =>
        {
            ShoppingCartEntry entry = new ShoppingCartEntry(
                id,
                invalidId,
                productId,
                quantity
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            ShoppingCartEntry entry = new ShoppingCartEntry(
                id,
                shoppingCartId,
                invalidId,
                quantity
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            ShoppingCartEntry entry = new ShoppingCartEntry(
                id,
                shoppingCartId,
                productId,
                invalidQuantity
            );
        });
    }
}