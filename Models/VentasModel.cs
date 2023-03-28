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
        public int orden { get; set; }
        public string plato { get; set; }
        public int canti { get; set; }
        public decimal precio { get; set; }
        public decimal subt { get; set; }
        public string mesero { get; set; }
        public string mesa { get; set; }
    }
}