
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiValhalla.Context;
using ApiValhalla.Clases;
using Microsoft.AspNetCore.Identity;
using ApiValhalla.Models;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private readonly AppDbContext _context;

        DatosRep datos;

        public ReporteController(AppDbContext context)
        {
            this._context = context;
            datos = new DatosRep(_context);
        }


        [HttpGet]
        [Route("ventasperi/{fi}/{ff}")]
        public ActionResult ventaperi(string fi, string ff)
        {
            List<Models.ComandaModel> recep = new List<Models.ComandaModel>();
            try
            {
                // List<Models.Orden> Resp = new List<Models.Orden>();
                List<ApiValhalla.Models.ComandaModel> carca = new List<ApiValhalla.Models.ComandaModel>();
                string FI = fi + " 00:00:00";
                string FF = ff + " 23:59:59";
                DateTime fFI = DateTime.Parse(FI);
                DateTime fFF = DateTime.Parse(FF);


                /* string query = "select co.ID_COMANDA,us.NOMBRE,(concat(pl.NOMBRE,', ',pl.DESCRIPCION)) as plato,dc.CANTIDAD,dc.PRECIO, (dc.CANTIDAD*dc.PRECIO) as subtotal from COMANDA co " +
                                "inner join COMAND_DETA cd on co.ID_COMANDA=cd.ID_COMANDA " +
                                "inner JOIN DETALLECOM dc on dc.ID_DETA= cd.ID_DETA " +
                                "inner join PLATILLO pl on pl.ID_PLAT= dc.id_plat " +
                                "inner join COMA_USU cu on cu.ID_COMANDA= co.ID_COMANDA " +
                                "inner join USUARIO us on us.ID_USU= cu.ID_USU " +
                                "where co.FECHA>='" + FI + "' and co.FECHA<='" + FF + "'";
                 var estado = _context.ventas.FromSqlRaw(query);*/

                var estado = from coma in _context.Comanda
                             join comd in _context.Comand_deta on coma.Id_comanda equals comd.Id_comanda
                             join detcom in _context.Detallecom on comd.Id_deta equals detcom.Id_deta
                             join plat in _context.Platillo on detcom.id_plat equals plat.Id_plat
                             join comus in _context.Coma_usu on coma.Id_comanda equals comus.Id_comanda
                             join usua in _context.Usuario on comus.Id_usu equals usua.Id_usu
                             where coma.Fecha >= fFI && coma.Fecha <= fFF
                             select new Models.VentasModel
                             {
                                 Id_comanda = coma.Id_comanda,
                                 Plato = $"{plat.Nombre}, {plat.Descripcion}",
                                 Nombre = usua.Nombre,
                                 Cantidad = detcom.Cantidad,
                                 Precio = detcom.Precio,
                                 Subtotal = detcom.Cantidad * detcom.Precio
                             };
                return Ok(estado);



            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpGet]
        [Route("PlatPrepa/{fi}/{ff}/")]
        public ActionResult PlatPrepa(string fi, string ff)
        {
            List<ComandaModel> recep = new List<ComandaModel>();
            try
            {
                // List<Models.Orden> Resp = new List<Models.Orden>();
                List<ApiValhalla.Models.ComandaModel> carca = new List<ApiValhalla.Models.ComandaModel>();
                string FI = fi + " 00:00:00";
                string FF = ff + " 23:59:59";
                DateTime fFI = DateTime.Parse(FI);
                DateTime fFF = DateTime.Parse(FF);


                /* string query = "select co.ID_COMANDA,us.NOMBRE,(concat(pl.NOMBRE,', ',pl.DESCRIPCION)) as plato,dc.CANTIDAD,dc.PRECIO, (dc.CANTIDAD*dc.PRECIO) as subtotal from COMANDA co " +
                                "inner join COMAND_DETA cd on co.ID_COMANDA=cd.ID_COMANDA " +
                                "inner JOIN DETALLECOM dc on dc.ID_DETA= cd.ID_DETA " +
                                "inner join PLATILLO pl on pl.ID_PLAT= dc.id_plat " +
                                "inner join COMA_USU cu on cu.ID_COMANDA= co.ID_COMANDA " +
                                "inner join USUARIO us on us.ID_USU= cu.ID_USU " +
                                "where co.FECHA>='" + FI + "' and co.FECHA<='" + FF + "'";
                 var estado = _context.ventas.FromSqlRaw(query);*/

                var estado = from coma in _context.Comanda
                             join comd in _context.Comand_deta on coma.Id_comanda equals comd.Id_comanda
                             join detcom in _context.Detallecom on comd.Id_deta equals detcom.Id_deta
                             join plat in _context.Platillo on detcom.id_plat equals plat.Id_plat
                             join cate in _context.Categoria on plat.Id_cat equals cate.Id_cat
                             where coma.Fecha >= fFI && coma.Fecha <= fFF
                             select new VentasModel
                             {
                                 Id_comanda = plat.Id_plat,
                                 Plato = $"{plat.Nombre}",
                                 Nombre = cate.Id_cat.ToString(),
                                 Cantidad = detcom.Cantidad,
                                 Precio = detcom.Precio,
                                 Subtotal = detcom.Cantidad * detcom.Precio
                             };
                return Ok(estado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("Allprodu")]
        public List<Models.ProductoModel> Allprodu()
        {
            List<Models.ProductoModel> recep = new List<Models.ProductoModel>();
            try
            {
                recep = datos.AllProd();
                return recep.ToList();
            }
            catch (Exception ex)
            {
                return (recep);
            }
        }



    }
}
