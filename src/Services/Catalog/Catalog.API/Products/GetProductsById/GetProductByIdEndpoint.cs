using Catalog.API.Models;

namespace Catalog.API.Products.GetProductsById;

public class GetProductByIdEndpoint : ICarterModule
{
    // public record GetProductByIdRequest(int ProductId);
    
    public record GetProductByIdResponse(Product Product);
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetProductById")
            .WithDescription("Gets a product by id");
    }
}