namespace Core.Tests.Domain;

using Core.Domain;

public class WarehouseEntryTest
{
    private Guid productId = Guid.CreateVersion7();
    private int quantity = 10;
    private Guid invalidProductId = Guid.Empty;
    private int invalidQuantity = -1;

    [Fact]
    public void CreateWarehouseEntryWorks()
    {
        WarehouseEntry entry = new WarehouseEntry(productId, quantity);

        Assert.Equal(productId, entry.ProductId);
        Assert.Equal(quantity, entry.Quantity);
    }

    [Fact]
    public void WarehouseEntryValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new WarehouseEntry(invalidProductId, quantity);
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new WarehouseEntry(productId, invalidQuantity);
        });
    }

    [Fact]
    public void WarehouseEntrySetQuantityWorks()
    {
        WarehouseEntry entry = new WarehouseEntry(productId, quantity);

        int updatedQuantity = 123;

        entry.SetQuantity(updatedQuantity);

        Assert.Equal(updatedQuantity, entry.Quantity);
        Assert.Throws<ArgumentException>(() => entry.SetQuantity(invalidQuantity));
    }
}