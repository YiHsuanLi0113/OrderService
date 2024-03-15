using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using OrderService.Data;
//using OrderService.Models;
builder.Services.AddDbContext<StoreContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<CheckoutService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var allowCors = builder.Configuration["AppConfig:Cors"].Split(",");
            app.UseCors(options =>
            options.WithOrigins(allowCors)
            .AllowAnyMethod()
            .AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
