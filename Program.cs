using Microsoft.EntityFrameworkCore;
using ConsultaCedulaApp.Data;

var builder = WebApplication.CreateBuilder(args);

// A�adir servicios
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

// Manejo de errores si no est� en desarrollo
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Archivos est�ticos y enrutamiento
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Establecer puerto din�mico para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

// Ruta por defecto: controlador Persona, acci�n Buscar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Persona}/{action=Buscar}/{id?}");

// Ejecutar la aplicaci�n
app.Run();

