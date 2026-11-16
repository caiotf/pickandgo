var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();   // documento em /openapi/v1.json

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "PickAndGo API v1");
    });
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");   // usado pelas probes do Kubernetes

app.Run();

// Permite que os testes de integração acessem a classe Program
public partial class Program { }