using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id_cat { get; set; }
        public string Nombre { get; set; }

    }
}
