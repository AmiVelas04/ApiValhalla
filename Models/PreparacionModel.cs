using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class PreparacionModel
    {
        [Key]
        public int Id_prep { get; set; }
        public int Id_usu { get; set; }
        public int Id_mesa { get; set; }
        public int Id_plat { get; set; }
        public int cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? Notas { get; set; }
        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }  
    }
}
