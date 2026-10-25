namespace Core.Domain;

public enum OrderStatus
{
    Created, 
    Completed, 
    Cancelled,
}
public class Order
{
    public readonly Guid Id;
    public readonly Guid UserId;
    public OrderStatus Status { get; private set; }
    public Dictionary<Guid, int> Products { get; }

    public Order(Guid id, Guid userId, Dictionary<Guid, int> products)
    {
        Id = id;
        UserId = userId;
        Products = products;
        Status = OrderStatus.Created;
    }

    public void Validate()
    {
        if(Id == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("Id", Id);
        }

        if(UserId == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("UserId", UserId);
        }
    }

    public void Cancel()
    {
        if(Status == OrderStatus.Completed)
        {
            throw new InvalidTransitionException("Completed", "Cancelled");
        }

        Status = OrderStatus.Cancelled;
    }

    public void Complete()
    {
        if(Status == OrderStatus.Cancelled)
        {
            throw new InvalidTransitionException("Cancelled", "Completed");
        }

        Status = OrderStatus.Completed;
    }
}
