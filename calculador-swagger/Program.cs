var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
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
        c.RoutePrefix = string.Empty; // Swagger ser� aberto na raiz do projeto
    });
}

app.UseRouting();

// Mapeia os controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// For�a o uso de HTTP ao inv�s de HTTPS
app.Run("http://localhost:5000");  // Especifique a URL como HTTP aqui
