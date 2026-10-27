namespace Core.Domain;


public class Order
{
    public readonly Guid Id;
    public readonly Guid UserId;
    public OrderStatus Status { get; private set; }
    public DeliveryInfo Delivery { get; private set; }
    public List<OrderEntry> Entries { get; private set; }
    public decimal Cost => Entries.Sum(e => e.DiscountedCost);

    public Order(
        Guid id, 
        Guid userId,
        OrderStatus status, 
        DeliveryInfo delivery,
        List<OrderEntry> entries
    )
    {
        Validate(
            id,
            userId,
            status,
            delivery,
            entries
        );

        Id = id; 
        UserId = userId;
        Status = status;
        Delivery = delivery;
        Entries = entries;
    }

    public void Validate(
        Guid id, 
        Guid userId,
        OrderStatus status, 
        DeliveryInfo delivery,
        List<OrderEntry> entries
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid order id");
        if(userId == Guid.Empty)
            throw new ArgumentException("Invalid order user id");
    }

    public bool CheckOrderStatusTransition(OrderStatus from, OrderStatus to)
    {
        switch (from)
        {
            case OrderStatus.Created:
                return to != OrderStatus.Completed;
            case OrderStatus.Purchased:
                return to != OrderStatus.Created;
            case OrderStatus.Completed:
                return false;
            case OrderStatus.Cancelled:
                return false;
        }

        return false;
    }

    public void SetStatus(OrderStatus newStatus)
    {
        bool isValidStatusChange = CheckOrderStatusTransition(Status, newStatus);

        if(!isValidStatusChange)
            throw new InvalidOperationException("Invalid order status change");
        
        Status = newStatus;
    }
}