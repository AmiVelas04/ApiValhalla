using Microsoft.EntityFrameworkCore;

namespace ApiValhalla.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Models.CajaModel> Caja { get; set; }
        public DbSet<Models.CategoriaModel> Categoria { get; set; }
        public DbSet<Models.ClienteModel> Clienteaja { get; set; }
        public DbSet<Models.Coma_cliModel> Coma_cli { get; set; }
        public DbSet<Models.Coma_mesaModel> Coma_mesa { get; set; }
        public DbSet<Models.Coma_usuModel> Coma_usu { get; set; }
        public DbSet<Models.Comand_detaModel> Comand_deta { get; set; }
        public DbSet<Models.ComandaModel> Comanda { get; set; }
        public DbSet<Models.DetallecomModel> Detallecom { get; set; }
        public DbSet<Models.MesaModel> Mesa { get; set; }
        public DbSet<Models.Plati_detaModel> Plati_deta { get; set; }
        public DbSet<Models.PlatilloModel> Platillo { get; set; }
        public DbSet<Models.RolModel> Rol { get; set; }
        public DbSet<Models.Sub_categoriaModel> Sub_Categoria { get; set; }
        public DbSet<Models.UsuarioModel> Usuario { get; set; }

        public DbSet<Models.PreparacionModel> Preparacion { get; set; }

        public DbSet<Models.PlatwCat> platwCats { get; set; }
        public DbSet<Models.VentasModel> ventas { get; set; }

        public DbSet<Models.ProductoModel> Producto { get; set; }
public DbSet<Models.Plati_ProdModel>Plati_Prod{get;set;}






    }
}
