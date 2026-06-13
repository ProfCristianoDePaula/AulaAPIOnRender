using Scalar.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Configurar o servidor para escutar na porta definida pela variável de ambiente "PORT" ou na porta 8080 por padrão
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Configurar proxy headers para HTTPS quando rodando atrás de um proxy (ex: Render)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

// Middleware para processar headers de proxy (HTTPS from proxy)
app.UseForwardedHeaders();

app.UseHttpsRedirection();

app.MapControllers();

app.MapOpenApi();

app.MapScalarApiReference(
    options =>
    {
        options.Title = "API v1.0";
        options.Theme = ScalarTheme.BluePlanet;
    }
);

app.Run();