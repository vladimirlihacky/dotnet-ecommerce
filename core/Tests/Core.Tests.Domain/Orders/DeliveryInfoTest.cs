namespace Core.Tests.Domain;

using Core.Domain;

public class DeliveryInfoTest
{
    [Fact]
    public void CreateDeliveryInfoWorks()
    {
        DeliveryInfo delivery = new DeliveryInfo("address");

        Assert.Equal("address", delivery.Address);
    }

    [Fact]
    public void DeliveryInfoValidationWorks()
    {
        Assert.Throws<ArgumentException>(() => { new DeliveryInfo(""); });
    }
}