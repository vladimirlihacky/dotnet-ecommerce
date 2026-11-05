namespace Core.Domain;


public class DeliveryInfo
{
    public Guid Id { get; set; }
    public string Address { get; private set; } = string.Empty;

    public DeliveryInfo(Guid id, string address)
    {
        Validate(id, address);
        
        Id = id; 
        Address = address;
    }

    private DeliveryInfo()
    {
    }

    private static void Validate(Guid id, string address)
    {
        if(id == Guid.Empty)
            throw new ValidationException("Invalid delivery info id");    
        if(string.IsNullOrEmpty(address))
            throw new ValidationException("Invalid delivery address");
    }
}