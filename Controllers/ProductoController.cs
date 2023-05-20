
using Microsoft.AspNetCore.Mvc;
using ApiValhalla.Context;
using ApiValhalla.Models;

namespace Apivalhalla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ProductoController(AppDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        [Route("IdProdMax")]
        public ActionResult GetMaxProd()
        {
            try
            {
                var orden = _context.Producto.Max(o => o.Id_prod);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdProdCount")]
        public ActionResult GetCountProd()
        {
            try
            {
                var orden = _context.Producto.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("PlaProCount/{idprod:int}/{idplat:int}")]
        public ActionResult GetCountProdPlat(int idprod, int idplat)
        {
            try
            {
                var orden = _context.Plati_Prod.Count(o => o.Id_prod == idprod && o.Id_plat == idplat);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("AllProd")]

        public ActionResult GetAllProd()
        {
            try
            {
                var orden = _context.Producto.ToList();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("prodbyid/{id:int}")]

        public ActionResult GetProdbyid(int id)
        {
            try
            {
                var orden = _context.Producto.Where(o => o.Id_prod == id);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }





        [HttpGet]
        [Route("SomeProd/{nom}/{desc}")]
        public ActionResult GetSomeProd(string nom, string desc)
        {
            string nombre = "", descri = "";
            if (nom != null)
                nombre = nom;

            if (desc != null)
                descri = desc;
            try
            {
                var orden = _context.Producto.Where(o => o.Nombre.Contains(nombre) || o.Desc.Contains(descri));
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("PlatProdbyPlat/{plat:int}")]
        public ActionResult GetSomeProd(int plat)
        {
            try
            {
                var orden = _context.Plati_Prod.Where(o => o.Id_plat == plat);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        //---------------------------------------post----------------------------------------------

        [HttpPost]
        [Route("SaveProd")]
        public ActionResult SaveSubCat(ProductoModel datos)
        {
            try
            {
                _context.Producto.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("SavePlatProd")]
        public ActionResult SavePlatProd(Plati_ProdModel datos)
        {
            try
            {
                _context.Plati_Prod.Add(datos);
                _context.SaveChanges();
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        //---------------------------------------editar----------------------------------------------

        [HttpPut]
        [Route("UpdProd")]
        public ActionResult PutProd(ProductoModel datos)
        {
            try
            {
                _context.Producto.Update(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdProdplat")]
        public ActionResult PutProdPlat(Plati_ProdModel datos)
        {
            try
            {
                _context.Plati_Prod.Update(datos);
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