using ApiValhalla.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public CategoriaController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("AllCat")]
        public ActionResult GetCat()
        {
            try
            {
                return Ok(_context.Categoria.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("AllSubCat/{cat}")]
        public ActionResult GetSubCat(int cat)
        {
            try
            {
                return Ok(_context.Sub_Categoria.Where(o => o.Id_cat == cat).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdCatMax")]
        public ActionResult GetMaxCat()
        {
            try
            {
                var orden = _context.Categoria.Max(o => o.Id_cat);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdSubCatMax")]
        public ActionResult GetMaxSubCat()
        {
            try
            {
                var orden = _context.Sub_Categoria.Max(o => o.Id_subcat);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdCatCount")]
        public ActionResult GetCountCat()
        {
            try
            {
                var orden = _context.Categoria.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdSubCatCount")]
        public ActionResult GetCountSubCat()
        {
            try
            {

                var orden = _context.Sub_Categoria.Count();
                // var orden = _context.SubCategoria.FromSqlRaw("select count(*) from sub_categoria");
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("Cat1/{cat}")]
        public ActionResult Get1Cat(string cat)
        {
            try
            {
                return Ok(_context.Categoria.Where(o => o.Id_cat.Equals(cat)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Subcat1/{sub}")]
        public ActionResult Get1SubCat(string sub)
        {
            try
            {
                return Ok(_context.Sub_Categoria.Where(o => o.Id_subcat.Equals(sub)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




        //----------------------------------------Guardar------------------------------------------------------------

        [HttpPost]
        [Route("Savecat")]
        public ActionResult SaveCat(Models.CategoriaModel datos)
        {
            try
            {
                _context.Categoria.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("Savesubcat")]
        public ActionResult SaveSubCat(Models.Sub_categoriaModel datos)
        {
            try
            {
                _context.Sub_Categoria.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdCat")]
        public async Task<IActionResult> PutCat(Models.CategoriaModel datos)
        {
            try
            {
                _context.Categoria.Update(datos);
                await _context.SaveChangesAsync();
                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("UpdSubCat")]
        public async Task<IActionResult> PutSubCat(Models.Sub_categoriaModel datos)
        {
            try
            {
                _context.Sub_Categoria.Update(datos);
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
