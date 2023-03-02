using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id_usu { get; set; }
        public int Id_rol { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        [MaxLength(8)]
        public string? Telefono { get; set; }
        public string? Dpi { get; set; }
        public string? User { get; set; }
        public string? Pass { get; set; }

    }
}
