using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class DetallecomModel
    {
        [Key]
 
        public int Id_deta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? Estado { get; set; }
    }
}
