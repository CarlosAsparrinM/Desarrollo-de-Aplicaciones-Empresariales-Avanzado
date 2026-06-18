namespace Lab12__Semana14.Response
{
    public class CursoResponse
    {
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int DuracionHoras { get; set; }

        public int IdInstructor { get; set; }

        public string NombreInstructor { get; set; }

        public bool Activo { get; set; }
    }
}
