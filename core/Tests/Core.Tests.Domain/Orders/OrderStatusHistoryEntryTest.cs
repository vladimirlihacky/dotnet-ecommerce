namespace Core.Tests.Domain;

using Core.Domain;

public class OrderStatusHistoryEntryTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid orderId = Guid.CreateVersion7();
    private OrderStatus fromStatus = OrderStatus.Created;
    private OrderStatus toStatus = OrderStatus.Purchased;
    private string cause = "any cause";
    private DateTimeOffset timestamp = DateTimeOffset.UtcNow;
    private Guid invalidId = Guid.Empty;
    private string invalidCause = "";

    [Fact]
    public void CreateOrderStatusHistoryEntryWorks()
    {
        OrderStatusHistoryEntry entry = new OrderStatusHistoryEntry(
            id,
            orderId,
            fromStatus,
            toStatus,
            cause,
            timestamp
        );

        Assert.Equal(id, entry.Id);
        Assert.Equal(orderId, entry.OrderId);
        Assert.Equal(fromStatus, entry.FromStatus);
        Assert.Equal(toStatus, entry.ToStatus);
    }

    [Fact]
    public void OrderStatusHistoryEntryValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OrderStatusHistoryEntry(
                invalidId,
                orderId,
                fromStatus,
                toStatus,
                cause,
                timestamp
            ); 
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new OrderStatusHistoryEntry(
                id,
                invalidId,
                fromStatus,
                toStatus,
                cause,
                timestamp
            ); 
        });
        Assert.Throws<ArgumentException>(() =>
        {
            new OrderStatusHistoryEntry(
                id,
                orderId,
                fromStatus,
                toStatus,
                invalidCause,
                timestamp
            ); 
        });
    }
}