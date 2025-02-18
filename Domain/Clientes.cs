using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Clientes
    {
        public int ClientesID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }
    }
}
