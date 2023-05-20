using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class VentasModel
    {
        [Key]
        public int Id_comanda { get; set; }
        public string? Nombre { get; set; }
        public string? Plato { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

    }
}