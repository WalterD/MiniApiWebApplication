using MiniApiWebApplication.Repositories;
using MiniApiWebApplication.Services.MinimalAPIs;

namespace MiniApiWebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
        builder.Services.AddSingleton<IMinimalAPI, ProductsAPI>();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Map endpoints of all minimal APIs.
        app.Services.GetServices<IMinimalAPI>()
                    .ToList()
                    .ForEach(x => x.MapMinimalApiEndpoints(app));

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(s => 
            { 
                s.DisplayRequestDuration();
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}