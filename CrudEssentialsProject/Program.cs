using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

app.MapControllers();

app.Run();
