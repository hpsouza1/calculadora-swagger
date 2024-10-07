var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o middleware HTTP para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Swagger será aberto na raiz do projeto
    });
}

app.UseRouting();

// Mapeia os controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Força o uso de HTTP ao invés de HTTPS
app.Run("http://localhost:5000");  // Especifique a URL como HTTP aqui
