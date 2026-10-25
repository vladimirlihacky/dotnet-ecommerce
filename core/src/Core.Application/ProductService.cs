namespace Core.Application;

using Core.Domain;
using Microsoft.Extensions.Logging;

public class ProductService
{
    private readonly IProductStorage _productStorage;
    private readonly ILogger _logger;

    public ProductService(
        IProductStorage productStorage,
        ILogger logger
    )
    {
        _productStorage = productStorage;
        _logger = logger;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        Product? product = await _productStorage.GetByIdAsync(id);

        if (product == null)
        {
            throw new NotFoundException($"Product {id} not found");
        }

        return product;
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return _productStorage.GetAllAsync();
    }

    public async Task<Product> Update(
        Guid id,
        string name,
        decimal cost,
        decimal? discount,
        string? description,
        Guid category,
        Media[] thumbnails
    )
    {
        Product product = await GetByIdAsync(id);

        product.Update(name, cost, discount, description, category, thumbnails);

        await _productStorage.SaveAsync(product);

        return product;
    }

    //TODO: Create
}