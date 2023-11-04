using MiniApiWebApplication.Data.Models;

namespace MiniApiWebApplication.Repositories;

public interface IProductsRepository
{
    Task<Product?> GetProductAsync(int productId);

    Task<List<Product>> GetProductsAsync();
}
