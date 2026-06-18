namespace Lab12__Semana14.Response
{
    public class MatriculaResponse
    {
        public int IdMatricula { get; set; }

        public int IdEstudiante { get; set; }

        public string NombreEstudiante { get; set; }

        public int IdCurso { get; set; }

        public string NombreCurso { get; set; }

        public DateTime FechaMatricula { get; set; }

        public string Estado { get; set; }

        public decimal MontoTotal { get; set; }
    }
}
