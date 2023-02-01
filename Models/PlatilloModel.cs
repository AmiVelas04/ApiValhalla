using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class PlatilloModel
    {
        [Key]
    
        public int Id_plat { get; set; }
        public int Id_cat { get; set; }
        public int Id_subcat { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public string? Foto { get; set; }

    }
}
