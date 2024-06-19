using GerenDeCadeiraDeDentista.Application.interfaces;
using GerenDeCadeiraDeDentista.Application.Mappings;
using GerenDeCadeiraDeDentista.Application.Services;
using GerenDeCadeiraDeDentista.Domain.Interfaces;
using GerenDeCadeiraDeDentista.Infrastructure.Data;
using GerenDeCadeiraDeDentista.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GerenDeCadeiraDeDentista.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);

//Registrar configurpação 
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


// Configure Entity Framework
builder.Services.AddDbContext<CadeiraDentistaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("GerenDeCadeiraDeDentista.API")));

// Configure Repositories and Services
builder.Services.AddScoped<ICadeiraDentistaRepository, CadeiraDentistaRepository>();
builder.Services.AddScoped<IServicoDeCadeiraDentista, ServicoDeCadeiraDentista>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MapeamentoDePerfil));

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
