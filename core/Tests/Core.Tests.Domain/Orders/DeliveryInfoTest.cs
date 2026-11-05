namespace Core.Tests.Domain;

using Core.Domain;

public class DeliveryInfoTest
{
    [Fact]
    public void CreateDeliveryInfoWorks()
    {
        DeliveryInfo delivery = new DeliveryInfo(Guid.CreateVersion7(), "address");

        Assert.Equal("address", delivery.Address);
    }

    [Fact]
    public void DeliveryInfoValidationWorks()
    {
        Assert.Throws<ValidationException>(() => { new DeliveryInfo(Guid.Empty, "address"); });
        Assert.Throws<ValidationException>(() => { new DeliveryInfo(Guid.CreateVersion7(), ""); });
    }
}