namespace Lab12__Semana14.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }

        public int IdEstudiante { get; set; }

        public int IdCurso { get; set; }

        public DateTime FechaMatricula { get; set; }

        public string Estado { get; set; }

        public decimal MontoTotal { get; set; }

        public bool IsDeleted { get; set; }
    }
}
