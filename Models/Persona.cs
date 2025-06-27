namespace ConsultaCedulaApp.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public required string Cedula { get; set; }

        public required string Nombre { get; set; }

        public int Edad { get; set; }
    }
}
