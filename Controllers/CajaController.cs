using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiValhalla.Context;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {

        private readonly AppDbContext _context;


        public CajaController(AppDbContext context)
        {
            this._context = context;

        }

        [HttpGet]
        [Route("IdCajaMax")]
        public ActionResult GetMaxCaja()
        {
            try
            {
                var orden = _context.Caja.Max(o => o.Id_caja);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdCajaCount")]
        public ActionResult GetCountCaja()
        {
            try
            {
                var orden = _context.Caja.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Operall/{id:int}/{fecha}")]
        public ActionResult GetCajaOpe(int id, string fecha)
        {
            string fi = fecha + " 00:00:00";
            string ff = fecha + " 23:59:59";
            DateTime Fini = DateTime.Parse(fi);
            DateTime Ffin = DateTime.Parse(ff);

            try
            {
                var opera = from operac in _context.Caja
                            join usua in _context.Usuario on operac.Id_usu equals usua.Id_usu
                            where operac.Id_usu.Equals(id) && operac.Fecha >= Fini && operac.Fecha <= Ffin
                            select new Models.RepCajaModel
                            {
                                id_ope = operac.Id_caja,
                                Descripcion = operac.Detalle,
                                Monto = operac.Monto,
                                Opero = usua.Nombre
                            };
                return Ok(opera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("OperTotal/{id:int}")]
        public ActionResult GetTotalOpe(int id)
        {
            try
            {
                var opera = from operac in _context.Caja
                            join usua in _context.Usuario on operac.Id_usu equals usua.Id_usu
                            where operac.Id_usu.Equals(id)
                            select new Models.RepCajaModel
                            {
                                id_ope = operac.Id_caja,
                                Descripcion = operac.Detalle,
                                Monto = operac.Monto,
                                Opero = usua.Nombre
                            };
                return Ok(opera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPost]
        [Route("Addcaja")]
        public ActionResult addPrep(Models.CajaModel datos)
        {
            try
            {
                _context.Caja.Add(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }






    }
}
