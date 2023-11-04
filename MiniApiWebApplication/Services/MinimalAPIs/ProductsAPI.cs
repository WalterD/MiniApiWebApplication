using MiniApiWebApplication.Data.Models;
using MiniApiWebApplication.Repositories;

namespace MiniApiWebApplication.Services.MinimalAPIs;

public class ProductsAPI : IMinimalAPI
{
    readonly IProductsRepository productsRepository;

    public ProductsAPI(IProductsRepository productsRepository)
    {
        this.productsRepository = productsRepository;
    }

    public void MapMinimalApiEndpoints(WebApplication webApplication)
    {
        // GET requests.
        webApplication.MapGet("/ProductsMinimalApi/GetProducts", GetProducts)
                      .Produces<List<Product>>()
                      .AllowAnonymous();
                      //.RequireAuthorization();
                      //.RequireAuthorization(<Policy Name>);

        webApplication.MapGet("/ProductsMinimalApi/GetProduct/{id:int}", GetProduct)
                      .Produces<Product>()
                      .AllowAnonymous();
    }

    //[Authorize]
    public async Task<IResult> GetProducts()
    {
        var products = await productsRepository.GetProductsAsync();
        return Results.Ok(products);
    }

    public async Task<IResult> GetProduct(int id)
    {
        var product = await productsRepository.GetProductAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(product);
    }
}
