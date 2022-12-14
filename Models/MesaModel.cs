using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class MesaModel
    {
        [Key]
        [Required]
        public int Id_mesa { get; set; }
        public int Numero { get; set; }
        public string? Ubicacion { get; set; }
        public string? Estado { get; set; }

    }
}
