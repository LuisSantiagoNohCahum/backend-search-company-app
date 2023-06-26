namespace backend_app.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public String Nombre { get; set; } = string.Empty;
        public String Rfc { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public String Direccion { get; set; }  = string.Empty;
        public String Email { get; set; } = string.Empty;
    }
}