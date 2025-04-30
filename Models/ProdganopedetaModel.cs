using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class ProdganopedetaModel
    {
        [Key]
        public int Id_opedeta { get; set; }
        public int Id_ope { get; set; }
        public int Id_prod { get; set; }
        public string? Operacion { get; set; }

        public decimal Costo { get; set; }

        public decimal Venta { get; set; }

        public int Cant { get; set; }

    }
}
