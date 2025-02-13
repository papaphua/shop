using Microsoft.EntityFrameworkCore;
using Shop.Server.BLL.CartItems;
using Shop.Server.BLL.Products;
using Shop.Server.BLL.Users;
using Shop.Server.DAL;
using Shop.Server.DAL.CartItems;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Server.DAL.Users;
using Shop.Shared.CartItems;
using Shop.Shared.Products;
using Shop.Shared.Users;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
services.AddScoped<IUnitOfWork>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddAutoMapper(options =>
    options.AddMaps(typeof(UserMaps).Assembly));

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ICartItemRepository, CartItemRepository>();

services.AddScoped<IUserService, UserService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ICartItemService, CartItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");
app.MapControllers();

app.Run();