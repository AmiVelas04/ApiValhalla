using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class PlatwCat
    {
        [Key]

        public int Id_plat { get; set; }
        public string? Categoria { get; set; }
        public string? Sub_cat { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public string? Foto { get; set; }
    }
}
