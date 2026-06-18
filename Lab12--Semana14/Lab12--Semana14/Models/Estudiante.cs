namespace Lab12__Semana14.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
