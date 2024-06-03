using Microsoft.EntityFrameworkCore;
using AnahiQuezadaBurgerAPI.Data;
using AnahiQuezadaBurgerAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AnahiQuezadaBurgerAPI.Controllers;

public static class AQPromoEndpoints
{
    public static void MapAQPromoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/AQPromo").WithTags(nameof(AQPromo));

        group.MapGet("/", async (AnahiQuezadaBurgerAPIContext db) =>
        {
            return await db.AQPromo.ToListAsync();
        })
        .WithName("GetAllAQPromos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<AQPromo>, NotFound>> (int aqpromoid, AnahiQuezadaBurgerAPIContext db) =>
        {
            return await db.AQPromo.AsNoTracking()
                .FirstOrDefaultAsync(model => model.AQPromoId == aqpromoid)
                is AQPromo model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAQPromoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int aqpromoid, AQPromo aQPromo, AnahiQuezadaBurgerAPIContext db) =>
        {
            var affected = await db.AQPromo
                .Where(model => model.AQPromoId == aqpromoid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.AQPromoId, aQPromo.AQPromoId)
                    .SetProperty(m => m.AQDescripcion, aQPromo.AQDescripcion)
                    .SetProperty(m => m.AQFechaPromo, aQPromo.AQFechaPromo)
                    .SetProperty(m => m.AQBurgerId, aQPromo.AQBurgerId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAQPromo")
        .WithOpenApi();

        group.MapPost("/", async (AQPromo aQPromo, AnahiQuezadaBurgerAPIContext db) =>
        {
            db.AQPromo.Add(aQPromo);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/AQPromo/{aQPromo.AQPromoId}",aQPromo);
        })
        .WithName("CreateAQPromo")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int aqpromoid, AnahiQuezadaBurgerAPIContext db) =>
        {
            var affected = await db.AQPromo
                .Where(model => model.AQPromoId == aqpromoid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAQPromo")
        .WithOpenApi();
    }
}
