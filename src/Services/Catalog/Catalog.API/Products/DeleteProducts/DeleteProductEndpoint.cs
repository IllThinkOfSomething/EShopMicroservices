namespace Catalog.API.Products.DeleteProducts;

// public record DeleteProductRequest(Guid Id);
public record DeleteProductResponse(bool Success);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{id}", async (Guid id, ISender sender) =>
        {
            await sender.Send(new DeleteProductCommand(id));
            return Results.Ok(new  DeleteProductResponse(true));
        })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Deletes the product");
    }
}