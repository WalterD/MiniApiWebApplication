using MiniApiWebApplication.Data.Models;

namespace MiniApiWebApplication.Repositories;

public class ProductsRepository : IProductsRepository
{
    public async Task<List<Product>> GetProductsAsync()
    {
        var product1 = await GetProductAsync(1);
        var product2 = await GetProductAsync(2);
        var products = new List<Product>() { product1, product2 };
        return products;
    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        var product = new Product() { ProductID = productId };
        return await Task.FromResult(product);
    }
}
