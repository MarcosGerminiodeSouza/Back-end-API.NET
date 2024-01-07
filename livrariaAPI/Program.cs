using livrariaAPI.Context;
using livrariaAPI.Services.LivroService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando referências aos serviços e Interfaces:
builder.Services.AddScoped<ILivroInterface, LivroService>();

// Adicionando credencias do MySQL:
string conexaoDb = builder.Configuration.GetConnectionString("ConexaoMySQL");

// Conectando com Banco de Dados mySQL:
builder.Services.AddDbContextPool<LivrariaContext>(options =>
        options.UseMySql(conexaoDb, ServerVersion.AutoDetect(conexaoDb)));

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

// Adicionando a configuração para o CORS:
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
