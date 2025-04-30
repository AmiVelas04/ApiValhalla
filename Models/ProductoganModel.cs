using System.ComponentModel.DataAnnotations;

namespace ApiValhalla.Models
{
  public class ProductoganModel
  {
    [Key]
    public int Id_prodgan { get; set; }
    public string? Producto { get; set; }
    public int Unidadescaja { get; set; }
    public decimal Costo { get; set; }

    public decimal Venta { get; set; }

    public int Cantidad { get; set; }

  }
}
