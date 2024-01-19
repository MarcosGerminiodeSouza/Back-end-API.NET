using livrariaAPI.Context;
using livrariaAPI.Services.AutorService;
using livrariaAPI.Services.CategoriaService;
using livrariaAPI.Services.EditoraService;
using livrariaAPI.Services.LivroService;
using livrariaAPI.Services.LivroVendaService;
using livrariaAPI.Services.UsuarioService;
using livrariaAPI.Services.VendaService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando referências aos serviços e Interfaces:
builder.Services.AddScoped<ILivroInterface, LivroService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddScoped<IEditoraInterface, EditoraService>();
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();
builder.Services.AddScoped<ILivroVendaInterface, LivroVendaService>();
builder.Services.AddScoped<IVendaInterface, VendaService>();

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
