using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Models
{
    public class Comand_detaModel
    {
        [Key]
      
        public int Id_deta { get; set; }
    
        public int Id_comanda { get; set; }

    }
}
