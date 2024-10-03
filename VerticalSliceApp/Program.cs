using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceApp.Features.Produtos;
using VerticalSliceApp.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// configurando o banco de dados InMemory
builder.Services.AddDbContext<ProdutoDbContext>(options => options.UseInMemoryDatabase("ProdutoDb"));

// Registra o ProdutoRepository
builder.Services.AddScoped<ProdutoRepository>();

// Configurando o MediatR
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

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

app.Run();
