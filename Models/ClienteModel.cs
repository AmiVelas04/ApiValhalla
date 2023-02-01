using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id_cliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        [MaxLength(8)]
        public string? Telefono { get; set;}
        public string? NIt { get; set; }
    }
}
