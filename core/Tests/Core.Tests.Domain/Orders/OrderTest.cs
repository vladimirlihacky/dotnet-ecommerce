namespace Core.Tests.Domain;

using Core.Domain;

public class OrderTest
{
    private Guid id = Guid.CreateVersion7();
    private Guid userId = Guid.CreateVersion7();
    private OrderStatus status = OrderStatus.Created;
    private DeliveryInfo delivery = new DeliveryInfo("address");
    private List<OrderEntry> entries = [
        new OrderEntry(
            Guid.CreateVersion7(),
            Guid.CreateVersion7(),
            "name",
            100,
            0,
            100,
            2
        ),
        new OrderEntry(
            Guid.CreateVersion7(),
            Guid.CreateVersion7(),
            "name",
            100,
            0.3m,
            70,
            1
        ),
    ];

    private Guid invalidId = Guid.Empty;

    [Fact]
    public void CreateOrderWorks()
    {
        Order order = new Order(
            id,
            userId,
            status,
            delivery,
            entries
        );

        Assert.Equal(id, order.Id);
        Assert.Equal(userId, order.UserId);
        Assert.Equal(status, order.Status);
        Assert.Equal(delivery, order.Delivery);
        Assert.Equal(entries, order.Entries);
    }

    [Fact]
    public void OrderValidationWorks()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Order(
                invalidId,
                userId,
                status,
                delivery,
                entries
            );
        });

        Assert.Throws<ArgumentException>(() =>
        {
            new Order(
                id,
                invalidId,
                status,
                delivery,
                entries
            );
        });
    }

    [Fact]
    public void CheckOrderStatusTransitionWorks()
    {
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Created,
                OrderStatus.Completed
            )
        );
        Assert.True(
            Order.CheckOrderStatusTransition(
                OrderStatus.Created,
                OrderStatus.Purchased
            )
        );
        Assert.True(
            Order.CheckOrderStatusTransition(
                OrderStatus.Created,
                OrderStatus.Cancelled
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Purchased,
                OrderStatus.Created
            )
        );
        Assert.True(
            Order.CheckOrderStatusTransition(
                OrderStatus.Purchased,
                OrderStatus.Completed
            )
        );
        Assert.True(
            Order.CheckOrderStatusTransition(
                OrderStatus.Purchased,
                OrderStatus.Cancelled
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Completed,
                OrderStatus.Cancelled
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Completed,
                OrderStatus.Purchased
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Completed,
                OrderStatus.Created
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Cancelled,
                OrderStatus.Completed
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Cancelled,
                OrderStatus.Purchased
            )
        );
        Assert.False(
            Order.CheckOrderStatusTransition(
                OrderStatus.Cancelled,
                OrderStatus.Created
            )
        );
    }

    [Fact]
    public void OrderSetStatusWorks()
    {
        Order order = new Order(
            id,
            userId,
            OrderStatus.Created,
            delivery,
            entries
        );

        order.SetStatus(OrderStatus.Purchased);

        Assert.Equal(OrderStatus.Purchased, order.Status);
    }

    [Fact]
    public void OrderCostCalculationWorks()
    {
        List<OrderEntry> entries = [
            new OrderEntry(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                "name",
                100,
                0,
                100,
                2
            ),
            new OrderEntry(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                "name",
                100,
                0.3m,
                70,
                1
            ),
        ];

        Order order = new Order(
            id,
            userId,
            status,
            delivery,
            entries
        );

        Assert.Equal(270, order.Cost);
    }
}