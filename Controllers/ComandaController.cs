
using Microsoft.AspNetCore.Mvc;
using ApiValhalla.Context;


namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ComandaController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("IdComMax")]
        public ActionResult GetMaxCom()
        {
            try
            {
                var orden = _context.Comanda.Max(o => o.Id_comanda);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdComCount")]
        public ActionResult GetCountCom()
        {
            try
            {
                var orden = _context.Comanda.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("IdComDetMax")]
        public ActionResult GetMaxPrep()
        {
            try
            {
                var orden = _context.Detallecom.Max(o => o.Id_deta);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdComDetCount")]
        public ActionResult GetCountPrep()
        {
            try
            {
                var orden = _context.Detallecom.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }





        [HttpPost]
        [Route("SaveCom")]
        public ActionResult SaveCom(Models.ComandaModel datos)
        {
            try
            {
                _context.Comanda.Add(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SaveComDet")]
        public ActionResult SaveComDet(Models.DetallecomModel datos)
        {
            try
            {
                _context.Detallecom.Add(datos);
                _context.SaveChanges();

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SaveDetayCom")]
        public ActionResult SaveAllComDet(Models.Comand_detaModel datos)
        {
            try
            {
                _context.Comand_deta.Add(datos);
                _context.SaveChanges();

                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SaveComUsu")]
        public ActionResult SaveComandUsu(Models.Coma_usuModel datos)
        {
            try
            {
                _context.Coma_usu.Add(datos);
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
