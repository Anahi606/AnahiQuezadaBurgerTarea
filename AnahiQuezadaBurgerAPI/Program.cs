using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnahiQuezadaBurgerAPI.Data;
using AnahiQuezadaBurgerAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnahiQuezadaBurgerAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnahiQuezadaBurgerAPIContext") ?? throw new InvalidOperationException("Connection string 'AnahiQuezadaBurgerAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapAQBurgerEndpoints();

app.MapAQPromoEndpoints();

app.Run();
