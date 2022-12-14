using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class RolModel
    {
        [Key]
        public int Id_rol { get; set; }
        public string? Nombre { get; set; }
        public string? Nivel { get; set;}


    }
}
