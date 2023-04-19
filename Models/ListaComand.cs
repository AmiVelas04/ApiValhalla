
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class ListaComand
    {
        [Key]

        public int Id_prep { get; set; }
        public string? Platillo { get; set; }
        public string? Desc { get; set; }
        public int Canti { get; set; }

        public decimal Precio { get; set; }

        public string? Estado { get; set; }

        public string? Notas { get; set; }
    }
}