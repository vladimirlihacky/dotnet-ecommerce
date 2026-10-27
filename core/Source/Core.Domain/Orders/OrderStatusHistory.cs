namespace Core.Domain;


public record OrderStatusHistoryEntry
{
    public readonly Guid Id; 
    public readonly Guid OrderId; 
    public readonly OrderStatus FromStatus; 
    public readonly OrderStatus ToStatus;
    public readonly string Cause; 
    public readonly DateTimeOffset Timestamp;

    public OrderStatusHistoryEntry(
        Guid id, 
        Guid orderId, 
        OrderStatus from,
        OrderStatus to, 
        string cause, 
        DateTimeOffset timestamp
    )
    {
        Validate(
            id, 
            orderId, 
            from,
            to,
            cause,
            timestamp
        );

        Id = id; 
        OrderId = orderId; 
        FromStatus = from; 
        ToStatus = to; 
        Cause = cause; 
        Timestamp = timestamp;
    }

    public void Validate(
        Guid id, 
        Guid orderId, 
        OrderStatus from,
        OrderStatus to, 
        string cause, 
        DateTimeOffset timestamp
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Invalid order status history entry id");
        if(orderId == Guid.Empty)
            throw new ArgumentException("Invalid order status history entry order id");
        if(string.IsNullOrEmpty(cause))
            throw new ArgumentException("Invalid order status history entry cause");
    }
}