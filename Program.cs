using Microsoft.EntityFrameworkCore;
using ConsultaCedulaApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=personas.db"));

var app = builder.Build();

// Iniciar la base de datos si es necesario
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(context);
}

// Manejo de errores si no está en desarrollo
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Archivos estáticos y enrutamiento
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Establecer puerto dinámico para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

// Ruta por defecto: controlador Persona, acción Buscar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Persona}/{action=Buscar}/{id?}");

// Ejecutar la aplicación
app.Run();

