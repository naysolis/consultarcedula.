using System.Linq;
using ConsultaCedulaApp.Models;

namespace ConsultaCedulaApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Personas.Any())
                return;

            var personas = new Persona[]
            {
                new Persona { Cedula = "123456789", Nombre = "Juan Pérez", Edad = 30 },
                new Persona { Cedula = "987654321", Nombre = "María Gómez", Edad = 25 }
            };

            context.Personas.AddRange(personas);
            context.SaveChanges();
        }
    }
}
