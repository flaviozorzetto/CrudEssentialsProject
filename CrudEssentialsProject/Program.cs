using CrudEssentialsProject.Context;
using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Repositories;
using CrudEssentialsProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
