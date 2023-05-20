using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class Plati_ProdModel
    {
        [Key]
        public int Id_prod { get; set; }

        public int Id_plat { get; set; }
        public int Cant { get; set; }
    }
}
