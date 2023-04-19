using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class RepCajaModel
    {
        [Key]
        public int id_ope { get; set; }
        public string operacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Opero { get; set; }


    }
}