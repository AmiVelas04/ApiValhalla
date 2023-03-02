using ApiValhalla.Context;
using ApiValhalla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiValhalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
          private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
           this._context = context;
        }

 [HttpGet]
        [Route("IdUsuMax")]
        public ActionResult GetMaxPrep()
        {
            try
            {
                var orden = _context.Preparacion.Max(o => o.Id_prep);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("IdUsuCount")]
        public ActionResult GetCountPrep()
        {
            try
            {
                var orden = _context.Preparacion.Count();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("AllUsu")]
        public async Task<IActionResult> getUsuarios()
        {
            return Ok(await _context.Usuario/*.Where(p=>p.Id_usu>1)*/.ToListAsync());
        }
  [HttpGet]
        [Route("AllRol")]
        public async Task<IActionResult> getRol()
        {
            return Ok(await _context.Rol.ToListAsync());
        }


        [HttpGet]
        [Route("OneUsu/{id:int}")]
        public ActionResult getOneUsuario(int id)
        {
            return Ok( _context.Usuario.Where(o=>o.Id_usu.Equals(id)).ToList());
        }



        [HttpPost]
        [Route("AddUsu")]
        public async Task<IActionResult> addUsuario(UsuarioModel datos)
        { 
        await _context.Usuario.AddAsync(datos);
            await _context.SaveChangesAsync();
            return Ok(datos);
        }

        [HttpPut]
         [Route("UpdUsu")]
        public async Task<IActionResult> UpdUsuario(UsuarioModel datos)
        {
            
            await _context.SaveChangesAsync();
            return Ok(datos);
        }
    }
}
