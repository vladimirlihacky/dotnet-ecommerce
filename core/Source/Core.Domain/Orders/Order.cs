namespace Core.Domain;


public class Order
{
    public Guid Id { get; private set; }
    public OrderStatus Status { get; private set; }
    public DeliveryInfo? Delivery { get; private set; }
    private List<OrderEntry> _entries { get; set; } = [];
    public IReadOnlyList<OrderEntry> Entries => _entries;
    private List<OrderStatusHistoryEntry> _statusHistory { get; set; } = [];
    public IReadOnlyList<OrderStatusHistoryEntry> StatusHistory => _statusHistory;
    public decimal Cost => _entries.Sum(e => e.DiscountedCost * e.Quantity);

    public Order(
        Guid id,
        OrderStatus status,
        DeliveryInfo delivery,
        List<OrderEntry> entries
    )
    {
        Validate(
            id,
            status,
            delivery,
            entries
        );

        Id = id;
        Status = status;
        Delivery = delivery;
        _entries = entries;
    }

    private Order()
    {
    }

    private static void Validate(
        Guid id,
        OrderStatus status,
        DeliveryInfo delivery,
        List<OrderEntry> entries
    )
    {
        if (id == Guid.Empty)
            throw new ValidationException("Invalid order id");
    }

    public static bool CheckOrderStatusTransition(OrderStatus from, OrderStatus to)
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

        if (!isValidStatusChange)
            throw new InvalidStateTransitionException("Invalid order status change");

        Status = newStatus;
    }
}