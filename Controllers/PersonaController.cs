using Microsoft.AspNetCore.Mvc;
using ConsultaCedulaApp.Data;
using System.Linq;

public class PersonaController : Controller
{
    private readonly AppDbContext _context;

    public PersonaController(AppDbContext context)
    {
        _context = context;
    }

    // Mostrar formulario
    public IActionResult Buscar()
    {
        return View();
    }
    public IActionResult Buscar2()
    {
        return View("Buscar2");
    }

    // Recibir y procesar formulario
    [HttpPost]
    public IActionResult Buscar(string cedula)
    {
        if (string.IsNullOrEmpty(cedula))
        {
            ViewBag.Mensaje = "Por favor ingresa una cédula válida";
            return View();
        }

        var persona = _context.Personas.FirstOrDefault(p => p.Cedula == cedula);

        if (persona == null)
        {
            ViewBag.Mensaje = "Cédula no encontrada";
            return View();
        }

        // Mostrar datos o mensaje de éxito
        ViewBag.Mensaje = $"Cédula: {persona.Cedula}, Nombre: {persona.Nombre}, Edad: {persona.Edad}";
        return View();
    }
}


