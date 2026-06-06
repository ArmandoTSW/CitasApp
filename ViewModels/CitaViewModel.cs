namespace CitasApp.ViewModels
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string Motivo { get; set; } = "";
        public string Estado { get; set; } = "";
        public string NombrePaciente { get; set; } = "";
        public string NombreMedico { get; set; } = "";
        public string EspecialidadMedico { get; set; } = "";
    }
}