
using Microsoft.AspNetCore.Mvc;
using ApiValhalla.Context;
using ApiValhalla.Clases;


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
        public List<Models.VentasModel> ventaperi(string fi, string ff)
        {
            List<Models.VentasModel> recep = new List<Models.VentasModel>();
            try
            {
                recep = datos.ventasPeriodo(fi, ff);
                return recep.ToList();
            }
            catch (Exception ex)
            {
                return (recep);
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
