using Microsoft.EntityFrameworkCore;
using ConsultaCedulaApp.Models;

namespace ConsultaCedulaApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
