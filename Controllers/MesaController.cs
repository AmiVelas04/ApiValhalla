using ApiValhalla.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public MesaController(AppDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        [Route("AllTab")]
        public ActionResult GetCat()
        {
            try
            {
                return Ok(_context.Mesa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpGet]
        [Route("IdTabMax")]
        public ActionResult GetMaxCat()
        {
            try
            {
                var orden = _context.Mesa.Max(o => o.Id_mesa);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpGet]
        [Route("IdTabCount")]
        public ActionResult GetCountCat()
        {
            try
            {
                var orden = _context.Mesa.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




        [HttpGet]
        [Route("Tab1/{id:int}")]
        public ActionResult Get1Cat(int id)
        {
            try
            {
                return Ok(_context.Mesa.Where(o => o.Id_mesa.Equals(id)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }





        //----------------------------------------Guardar------------------------------------------------------------

        [HttpPost]
        [Route("SaveTab")]
        public ActionResult SaveCat(Models.MesaModel datos)
        {
            try
            {
                _context.Mesa.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("UpdTab")]
        public async Task<ActionResult> updMes(Models.MesaModel datos)
        {
            try
            {
                _context.Mesa.Update(datos);
                await _context.SaveChangesAsync();
                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
