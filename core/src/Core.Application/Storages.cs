namespace Core.Application;

using core.Domain;
using Core.Domain;

public interface IOrderStorage
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
    Task SaveAsync(Order order);
}

public interface IShoppingCartStorage
{
    Task<ShoppingCart?> GetByIdAsync(Guid id);
    Task<ShoppingCart> GetAllAsync();
    Task<ShoppingCart?> GetByUserIdAsync(Guid userId);
    Task SaveAsync(ShoppingCart shoppingCart);
    Task DeleteAsync(Guid id);
}

public interface IUserStorage
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task SaveAsync(User user);
    Task DeleteAsync(Guid id);
}

public interface IProductStorage
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task SaveAsync(Product product);
    Task DeleteAsync(Guid id);
}

public interface IAccountStorage
{
    Task<Account> GetSystemAccountAsync();
    Task<T?> GetByIdAsync<T>(Guid id) where T : Account; 
    Task<UserAccount?> GetByUserIdAsync(Guid userId); 
    Task<HoldAccount?> GetHoldByAccountIdAsync(Guid accountId); 
    Task<T> SaveAsync<T>(T account) where T : Account;
}
public interface IPaymentOperationStorage
{
    Task<PaymentOperation?> GetByIdAsync(Guid id);
    Task<IEnumerable<PaymentOperation>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<PaymentOperation>> GetByAccountIdAsync(Guid accountId);
    Task SaveAsync(PaymentOperation operation);
}