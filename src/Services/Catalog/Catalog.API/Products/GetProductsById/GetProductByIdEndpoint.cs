using Catalog.API.Models;

namespace Catalog.API.Products.GetProductsById;

public class GetProductByIdEndpoint : ICarterModule
{
    public record GetProductByIdRequest(int ProductId);
    
    public record GetProductByIdResponse(Product Product);
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (GetProductByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductByIdQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .WithSummary("GetProductById")
            .WithDescription("Gets a product by id");
    }
}