using System.ComponentModel.DataAnnotations;

namespace Backend_API_LastProject.Request
{
    public class ClientesRequests_V1
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        public int Telefono { get; set; }
        
    }
}
