using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class Plati_detaModel
    {
        [Key]
        [Required]
        public int Id_deta { get; set; }
        [Key]
        [Required]
        public int Id_plati { get; set; }

    }
}
