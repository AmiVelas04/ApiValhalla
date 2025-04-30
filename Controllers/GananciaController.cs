using ApiValhalla.Context;
using ApiValhalla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GananciaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public GananciaController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("IdProdMax")]
        public ActionResult GetMaxProd()
        {
            try
            {
                var orden = _context.Productogan.Max(o => o.Id_prodgan);
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
                var orden = _context.Productogan.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdGanOpeMax")]
        public ActionResult GetMaxGanOpe()
        {
            try
            {
                var orden = _context.Produganope.Max(o => o.Id_ope);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdGanOpeCount")]
        public ActionResult GetCountGanOpe()
        {
            try
            {
                var orden = _context.Produganope.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdGanOpeMaxDeta")]
        public ActionResult GetMaxGanOpeDeta()
        {
            try
            {
                var orden = _context.Prodganopedeta.Max(o => o.Id_opedeta);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdGanOpeCountDeta")]
        public ActionResult GetCountGanOpeDeta()
        {
            try
            {
                var orden = _context.Prodganopedeta.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("Allprodus")]
        public ActionResult allprodusgan()
        {
            try
            {
                var result = _context.Productogan.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("AllprodOpe")]
        public ActionResult allprodusganOpe()
        {
            try
            {
                var result = _context.Produganope.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpGet]
        [Route("AllprodOpeDet")]
        public ActionResult allprodusganOpeDeta()
        {
            try
            {
                var result = _context.Prodganopedeta.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("Allprodpend")]
        public ActionResult AllProdPend()
        {
            try
            {
                var result = from detas in _context.Prodganopedeta
                             join opes in _context.Produganope on detas.Id_ope equals opes.Id_ope
                             where opes.Estado.Equals("Hecho")
                             select detas;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ProdOpePend/{fecha}")]
        public ActionResult ProdOpePendD(string fecha)
        {
            DateTime fech = DateTime.Parse($"{fecha} 23:59:59");
            try
            {
                var result = from opes in _context.Produganope
                             where opes.Estado.Equals("Hecho") && opes.Fecha <= fech
                             select opes;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ProdOpePendAll/{fechaI}/{fechaF}")]
        public ActionResult ProdOpePendDateAll(string fechaI, string fechaF)
        {
            DateTime FI = DateTime.Parse($"{fechaI} 00:00:00");
            DateTime FF = DateTime.Parse($"{fechaF} 23:59:59");

            try
            {
                var result = from opes in _context.Produganope
                             where opes.Estado.Equals("Hecho") && opes.Fecha <= FF && opes.Fecha >= FI
                             select opes;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("OpesDates/{fechaI}/{fechaF}")]
        public ActionResult ProdOpesDate(string fechaI, string fechaF)
        {
            DateTime FI = DateTime.Parse($"{fechaI} 00:00:00");
            DateTime FF = DateTime.Parse($"{fechaF} 23:59:59");
            try
            {
                var result = from opes in _context.Produganope
                             where opes.Fecha <= FF && opes.Fecha >= FI
                             select opes;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("OpesUnique/{id:int}")]
        public ActionResult ProdOpesUnique(int id)
        {
            try
            {
                var result = from opes in _context.Produganope
                             where opes.Id_ope == id
                             select opes;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("Productopes/{id:int}")]
        public ActionResult ProductOpes(int id)
        {
            try
            {
                var result = from prods in _context.Productogan
                             join opedeta in _context.Prodganopedeta on prods.Id_prodgan equals opedeta.Id_prod
                             join opes in _context.Produganope on opedeta.Id_ope equals opes.Id_ope
                             where opes.Id_ope == id
                             select prods;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        //Todo--------------------------UPDATE--------------------------------------

        [HttpPut]
        [Route("Updprod")]
        public ActionResult updPrep(ProductoganModel datos)
        {
            try
            {
                _context.Productogan.Update(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("UpdOpeprod")]
        public ActionResult updOpePrep(ProduganopeModel datos)
        {
            try
            {
                _context.Produganope.Update(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        //Todo--------------------------SAVE--------------------------------------
        [HttpPost]
        [Route("Addprod")]
        public ActionResult addPrep(ProductoganModel datos)
        {
            try
            {
                _context.Productogan.Add(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("Addope")]
        public ActionResult addOpe(ProduganopeModel datos)
        {
            try
            {
                _context.Produganope.Add(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("Addopedeta")]
        public ActionResult addOpeDeta(ProdganopedetaModel datos)
        {
            try
            {
                _context.Prodganopedeta.Add(datos);
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
