using System.ComponentModel.DataAnnotations;

namespace Backend_API_LastProject.Request
{
    public class ProductosRequests_V1
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
