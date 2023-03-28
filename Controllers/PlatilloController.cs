using ApiValhalla.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {

        private readonly AppDbContext _context;


        public PlatilloController(AppDbContext context)
        {
            this._context = context;
        }

        //----------------------------------------Obtener------------------------------------------------------------
        [HttpGet]
        [Route("AllPlat")]
        public ActionResult GetAllPlat()
        {
            try
            {
                var result = _context.Platillo.ToList();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("AllPlatwCat")]
        public ActionResult GetAllPlatwCat()
        {
            try
            {
                var result = from plat in _context.Platillo
                             join cat in _context.Categoria on plat.Id_cat equals cat.Id_cat
                             join scat in _context.Sub_Categoria on plat.Id_subcat equals scat.Id_subcat
                             select new Models.PlatwCat
                             {
                                 Id_plat= plat.Id_plat,
                                 Categoria= cat.Nombre,
                                 Sub_cat=scat.Nombre,
                                 Nombre=plat.Nombre,
                                 Descripcion= plat.Descripcion,
                                 Precio= plat.Precio,
                                 Activo= plat.Activo,
                                 Foto= plat.Foto,
                             };
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("Plat1/{id:int}")]
        public ActionResult GetAllPlat(int id)
        {
            try
            {
                //var result = _context.Platillo.Where(o => o.Id_plat.Equals(id)).ToList();
                var result = from plato in _context.Platillo
                             where plato.Id_plat.Equals(id)
                             select plato;
                return Ok(result.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("IdPlatMax")]
        public ActionResult GetMaxCat()
        {
            try
            {
                var orden = _context.Platillo.Max(o => o.Id_plat);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdPlatCount")]
        public ActionResult GetCountCat()
        {
            try
            {
                var orden = _context.Platillo.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Platby/{cat}/{scat}")]
        public ActionResult Getplatby(int cat, int scat)
        {
            try
            {
                var result = from plati in _context.Platillo
                             join cate in _context.Categoria on plati.Id_cat equals cate.Id_cat
                             join scate in _context.Sub_Categoria on plati.Id_subcat equals scate.Id_subcat
                             select plati;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       


        //----------------------------------------Guardar------------------------------------------------------------

        [HttpPost]
        [Route("Saveplat")]
        public ActionResult SaveSubCat(Models.PlatilloModel datos)
        {
            try
            {
                _context.Platillo.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //----------------------------------------Editar------------------------------------------------------------

        [HttpPut]
        [Route("UpdPlat")]
        public async Task<IActionResult> PutSubCat(Models.PlatilloModel datos)
        {
            try
            {
                _context.Platillo.Update(datos);
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
