using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class ComandaModel
    {
        [Key]
        [Required]
        public int Id_comanda { get; set; }
        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public int Comensales { get; set; }
        public string? Notas { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public string? Estado { get; set;}

    }
}
