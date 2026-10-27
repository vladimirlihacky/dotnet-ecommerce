namespace Core.Domain;


public record DeliveryInfo
{
    public string Address { get; private set; }

    public DeliveryInfo(string address)
    {
        Address = address;
    }
}