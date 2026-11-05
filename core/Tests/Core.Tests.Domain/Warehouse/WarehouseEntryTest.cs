namespace Core.Tests.Domain;

using Core.Domain;

public class WarehouseEntryTest
{
    private Guid entryId = Guid.CreateVersion7();
    private Guid productId = Guid.CreateVersion7();
    private int quantity = 10;
    private Guid invalidId = Guid.Empty;
    private int invalidQuantity = -1;

    [Fact]
    public void CreateWarehouseEntryWorks()
    {
        WarehouseEntry entry = new WarehouseEntry(entryId, productId, quantity);

        Assert.Equal(productId, entry.ProductId);
        Assert.Equal(quantity, entry.Quantity);
    }

    [Fact]
    public void WarehouseEntryValidationWorks()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new WarehouseEntry(invalidId, productId, quantity);
        });
        Assert.Throws<ValidationException>(() =>
        {
            new WarehouseEntry(entryId, invalidId, quantity);
        });
        Assert.Throws<ValidationException>(() =>
        {
            new WarehouseEntry(entryId, productId, invalidQuantity);
        });
    }

    [Fact]
    public void WarehouseEntrySetQuantityWorks()
    {
        WarehouseEntry entry = new WarehouseEntry(entryId, productId, quantity);

        int updatedQuantity = 123;

        entry.SetQuantity(updatedQuantity);

        Assert.Equal(updatedQuantity, entry.Quantity);
        Assert.Throws<ValidationException>(() => entry.SetQuantity(invalidQuantity));
    }
}