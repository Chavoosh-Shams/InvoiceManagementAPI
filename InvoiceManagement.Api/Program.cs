using InvoiceManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using InvoiceManagement.Api.Models.Services.Contracts;
using InvoiceManagement.Api.ApplicationServices.Services;
using InvoiceManagement.Api.Models.Services.Repositories;
using InvoiceManagement.Api.ApplicationServices.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [- AddDbContext<>() -]
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region [- AddScoped<>() -]
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();

builder.Services.AddScoped<IOrderHeaderRepository, OrderHeaderRepository>();
builder.Services.AddScoped<IOrderHeaderApplicationService, OrderHeaderApplicationService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
