namespace Core.Application;

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