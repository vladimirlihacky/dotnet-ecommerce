namespace Core.Domain;

public enum OrderStatus
{
    Created, 
    Completed, 
    Cancelled,
}
public class Order
{
    public Guid Id { get; private set; }
    public OrderStatus Status { get; private set; }
    public Dictionary<Guid, int> Products { get; }

    public Order(Guid id, Dictionary<Guid, int> products)
    {
        Id = id;
        Products = products;
        Status = OrderStatus.Created;
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
