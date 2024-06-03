using Microsoft.EntityFrameworkCore;
using AnahiQuezadaBurgerAPI.Data;
using AnahiQuezadaBurgerAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AnahiQuezadaBurgerAPI.Controllers;

public static class AQBurgerEndpoints
{
    public static void MapAQBurgerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/AQBurger").WithTags(nameof(AQBurger));

        group.MapGet("/", async (AnahiQuezadaBurgerAPIContext db) =>
        {
            return await db.AQBurger.ToListAsync();
        })
        .WithName("GetAllAQBurgers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<AQBurger>, NotFound>> (int aqburgerid, AnahiQuezadaBurgerAPIContext db) =>
        {
            return await db.AQBurger.AsNoTracking()
                .FirstOrDefaultAsync(model => model.AQBurgerId == aqburgerid)
                is AQBurger model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAQBurgerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int aqburgerid, AQBurger aQBurger, AnahiQuezadaBurgerAPIContext db) =>
        {
            var affected = await db.AQBurger
                .Where(model => model.AQBurgerId == aqburgerid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.AQBurgerId, aQBurger.AQBurgerId)
                    .SetProperty(m => m.AQName, aQBurger.AQName)
                    .SetProperty(m => m.AQWithCheese, aQBurger.AQWithCheese)
                    .SetProperty(m => m.AQPrecio, aQBurger.AQPrecio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAQBurger")
        .WithOpenApi();

        group.MapPost("/", async (AQBurger aQBurger, AnahiQuezadaBurgerAPIContext db) =>
        {
            db.AQBurger.Add(aQBurger);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/AQBurger/{aQBurger.AQBurgerId}",aQBurger);
        })
        .WithName("CreateAQBurger")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int aqburgerid, AnahiQuezadaBurgerAPIContext db) =>
        {
            var affected = await db.AQBurger
                .Where(model => model.AQBurgerId == aqburgerid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAQBurger")
        .WithOpenApi();
    }
}
