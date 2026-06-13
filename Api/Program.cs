using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Configurar o servidor para escutar na porta definida pela variável de ambiente "PORT" ou na porta 8080 por padrão
builder.WebHost.UseUrls(
 $"http://*:{Environment.GetEnvironmentVariable("PORT") ?? "8080"}"
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

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