using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class CajaModel
    {
        [Key]
       public int Id_caja { get; set; }
        public int Id_usu { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public String? Detalle { get; set; }
    }
}
