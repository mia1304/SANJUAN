

// Conexión a la base de datos SANJUAN
using Microsoft.EntityFrameworkCore;
using SANJUAN.Data;
using SANJUAN.Data;
var builder = WebApplication.CreateBuilder(args);

// Conexión a la base de datos SANJUAN
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // asegúrate de que coincida el nombre


// Solo API REST (sin vistas)
builder.Services.AddControllers();

// Autorización (necesaria si usas UseAuthorization)
builder.Services.AddAuthorization();

// Swagger y documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Rutas tipo API REST
app.MapControllers();

app.Run();


