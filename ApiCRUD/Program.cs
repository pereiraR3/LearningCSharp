using ApiCRUD.Data;
using ApiCRUD.Repositories;
using ApiCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;  // Necessário para usar CultureInfo

var builder = WebApplication.CreateBuilder(args);

// Definir a cultura global para invariant
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Adicionar serviços ao contêiner.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar os controladores no contêiner de serviços
builder.Services.AddControllers();

// Registrar o DbContext com o nome correto
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ApiCRUDDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
    );

// Injetar o repositório no contêiner de serviços
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();

app.Run();
