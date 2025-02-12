using Microsoft.EntityFrameworkCore;
using Shop.Server.DAL;
using Shop.Server.DAL.CartItems;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Server.DAL.Users;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
services.AddScoped<IUnitOfWork>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ICartItemRepository, CartItemRepository>();

var app = builder.Build();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");
app.MapControllers();

app.Run();