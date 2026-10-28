namespace Core.Domain;


public record DeliveryInfo
{
    public string Address { get; private set; }

    public DeliveryInfo(string address)
    {
        Validate(address);
        
        Address = address;
    }

    public void Validate(string address)
    {
        if(string.IsNullOrEmpty(address))
            throw new ArgumentException("Invalid delivery address");
    }
}