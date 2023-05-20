using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class ProductoModel
    {
        [Key]
        public int Id_prod { get; set; }
        public String? Nombre { get; set; }
        public String? Desc { get; set; }

        public int Cant { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio_v1 { get; set; }

    }
}
