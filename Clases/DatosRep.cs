using ApiValhalla.Context;
using ApiValhalla.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiValhalla.Clases
{
    public class DatosRep
    {
        private readonly AppDbContext _context;

        public DatosRep(AppDbContext context)
        {
            this._context = context;
        }
         
        public List<ApiValhalla.Models.VentasModel> ventasPeriodo(string fechai, string fechaf)
        {
            // List<Models.Orden> Resp = new List<Models.Orden>();
            List<ApiValhalla.Models.VentasModel> carca = new List<ApiValhalla.Models.VentasModel>();
            string fi = fechai + " 00:00:00";
            string ff = fechaf + " 23:59:59";
            try
            {
                string query = "select co.ID_COMANDA,us.NOMBRE,(concat(pl.NOMBRE,', ',pl.DESCRIPCION)) as plato,dc.CANTIDAD,dc.PRECIO, (dc.CANTIDAD*dc.PRECIO) as subtotal from COMANDA co " +
                               "inner join COMAND_DETA cd on co.ID_COMANDA=cd.ID_COMANDA " +
                               "inner JOIN DETALLECOM dc on dc.ID_DETA= cd.ID_DETA " +
                               "inner join PLATILLO pl on pl.ID_PLAT= dc.id_plat " +
                               "inner join COMA_USU cu on cu.ID_COMANDA= co.ID_COMANDA " +
                               "inner join USUARIO us on us.ID_USU= cu.ID_USU " +
                               "where co.FECHA>='" + fi + "' and co.FECHA<='" + ff + "'";

                var estado = _context.ventas.FromSqlRaw(query).ToList();
                return estado.ToList();
            }
            catch (System.Exception ex)
            {
                return carca;
                // return reo;
            }
        }

        public List<ApiValhalla.Models.ProductoModel> AllProd()
        {
            // List<Models.Orden> Resp = new List<Models.Orden>();
            List<ApiValhalla.Models.ProductoModel> carca = new List<ApiValhalla.Models.ProductoModel>();
            try
            {
                var prod = _context.Producto.ToList();
                carca = prod;
                return carca;
            }
            catch (System.Exception ex)
            {
                return carca;
                // return reo;
            }

        }
    }
}