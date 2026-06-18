namespace Lab12__Semana14.Models
{
    public class Instructor
    {
        public int IdInstructor { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Especialidad { get; set; }

        public string Email { get; set; }

        public bool Activo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
