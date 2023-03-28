
using Microsoft.AspNetCore.Mvc;
using ApiValhalla.Context;
using ApiValhalla.Clases;


namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        DatosRep datos;
        private readonly AppDbContext _context;


        public ReporteController(AppDbContext context)
        {
            this._context = context;
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

    }
}
