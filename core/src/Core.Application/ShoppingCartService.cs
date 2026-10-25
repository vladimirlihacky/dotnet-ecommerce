namespace Core.Application;

using Core.Domain;
using Microsoft.Extensions.Logging;

public class ShoppingCartService
{
    private readonly IShoppingCartStorage _shoppingCartStorage; 
    private readonly ProductService _productService;
    private readonly ILogger _logger;
    
    public ShoppingCartService(
        IShoppingCartStorage shoppingCartStorage, 
        ILogger logger,
        ProductService productService
    )
    {
        _shoppingCartStorage = shoppingCartStorage;
        _productService = productService;
        _logger = logger;
    }

    public async Task<ShoppingCart> Create(Guid id, Guid userId)
    {
        ShoppingCart shoppingCart = new ShoppingCart(id, userId);

        await _shoppingCartStorage.SaveAsync(shoppingCart);

        return shoppingCart;
    }

    public async Task<ShoppingCart> GetByIdAsync(Guid id)
    {
        ShoppingCart? shoppingCart = await _shoppingCartStorage.GetByIdAsync(id);

        if(shoppingCart == null)
        {
            throw new NotFoundException($"Shopping cart {id} not found");
        }

        return shoppingCart;
    }

    public async Task<ShoppingCart> GetByUserIdAsync(Guid userId)
    {
        ShoppingCart? shoppingCart = await _shoppingCartStorage.GetByUserIdAsync(userId);

        if(shoppingCart == null)
        {
            throw new NotFoundException($"Shopping cart for user {userId} not found");
        }

        return shoppingCart;
    }

    public async Task<ShoppingCart> SetProductAmountAsync(Guid id, Guid productId, int amount)
    {
        ShoppingCart shoppingCart = await GetByIdAsync(id);
        Product product = await _productService.GetByIdAsync(productId);

        if(product == null)
        {
            throw new InvalidRequestException("Invalid request");
        }

        shoppingCart.SetProductAmount(product.Id, amount);

        await _shoppingCartStorage.SaveAsync(shoppingCart);

        return shoppingCart;
    }

    public async Task<ShoppingCart> RemoveProductAsync(Guid id, Guid productId)
    {
        ShoppingCart shoppingCart = await GetByIdAsync(id);
        
        shoppingCart.RemoveProduct(productId);

        await _shoppingCartStorage.SaveAsync(shoppingCart);

        return shoppingCart;
    }

    public async Task<ShoppingCart> ClearAsync(Guid id)
    {
        ShoppingCart shoppingCart = await GetByIdAsync(id);

        shoppingCart.Clear();

        await _shoppingCartStorage.SaveAsync(shoppingCart);

        return shoppingCart;
    }
}