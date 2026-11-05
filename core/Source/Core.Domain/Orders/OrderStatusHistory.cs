namespace Core.Domain;


public class OrderStatusHistoryEntry
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public OrderStatus FromStatus { get; private set; }
    public OrderStatus ToStatus { get; private set; }
    public string Cause { get; private set; } = string.Empty;
    public DateTimeOffset Timestamp { get; private set; }

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

    private OrderStatusHistoryEntry()
    {
    }

    private static void Validate(
        Guid id,
        Guid orderId,
        OrderStatus from,
        OrderStatus to,
        string cause,
        DateTimeOffset timestamp
    )
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid order status history entry id");
        if (orderId == Guid.Empty)
            throw new ValidationException("Invalid order status history entry order id");
        if (string.IsNullOrEmpty(cause))
            throw new ValidationException("Invalid order status history entry cause");
    }
}