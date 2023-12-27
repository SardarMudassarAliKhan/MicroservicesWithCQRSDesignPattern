using MicroservicesWithCQRSDesignPattern.AppDbContext;
using MicroservicesWithCQRSDesignPattern.Handlers;
using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Quries.CommandModel;
using MicroservicesWithCQRSDesignPattern.Quries.QueryModel;
using MicroservicesWithCQRSDesignPattern.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // Replace with your database provider and connection string
});
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
builder.Services.AddTransient<IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>>, GetProductsQueryHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
