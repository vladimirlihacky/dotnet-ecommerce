namespace Core.Application;

using System.Transactions;
using Core.Domain;
using Microsoft.Extensions.Logging;

public class OrderService
{
    private readonly IOrderStorage _orderStorage; 
    private readonly ILogger _logger;
    private readonly ShoppingCartService _shoppingCartService; 
    
    public OrderService(
        IOrderStorage orderStorage, 
        ShoppingCartService shoppingCartService, 
        ILogger logger
    )
    {
        _orderStorage = orderStorage; 
        _logger = logger;
        _shoppingCartService = shoppingCartService;
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        Order? order = await _orderStorage.GetByIdAsync(id);

        if(order == null)
        {
            throw new NotFoundException($"Order {id} not found");
        }

        return order; 
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return _orderStorage.GetAllAsync();
    }

    public Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId)
    {
        return _orderStorage.GetByUserIdAsync(userId);
    }

    public async Task<Order> CreateFromUserShoppingCartAsync(Guid userId)
    {
        Guid id = Guid.CreateVersion7();

        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(5),
        };

        using var scope = new TransactionScope(
            TransactionScopeOption.Required, 
            transactionOptions,
            TransactionScopeAsyncFlowOption.Enabled
        );

        try
        {
            ShoppingCart shoppingCart = await _shoppingCartService.GetByUserIdAsync(userId);
            Order order = new Order(id, userId, shoppingCart.Products);

            await _orderStorage.SaveAsync(order);
            await _shoppingCartService.ClearAsync(shoppingCart.Id);
            
            scope.Complete();

            return order;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Transaction failed"); 
            throw;
        }
    }

    public async Task<Order> CompleteAsync(Guid id)
    {
        Order? order = await GetByIdAsync(id);

        order.Complete();
        
        await _orderStorage.SaveAsync(order);

        return order; 
    }

    public async Task<Order> CancelAsync(Guid id)
    {
        Order? order = await GetByIdAsync(id);

        order.Cancel();
        
        await _orderStorage.SaveAsync(order);

        return order; 
    }
}