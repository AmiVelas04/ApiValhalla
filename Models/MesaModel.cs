using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
    public class MesaModel
    {
        [Key]

        public int Id_mesa { get; set; }
        public string? Numero { get; set; }
        public string? Ubicacion { get; set; }
        public string? Estado { get; set; }

    }
}
