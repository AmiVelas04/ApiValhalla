using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class ProduganopeModel
    {
        [Key]
        public int Id_ope { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_usu { get; set; }
        public string? Estado { get; set; }

    }
}
