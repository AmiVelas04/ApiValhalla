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
        private readonly AppDbContext dbContext;
        public UsuarioController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> getUsuarios()
        {
            return Ok(await dbContext.Usuario.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> addUsuario(UsuarioModel datos)
        { 
        await dbContext.Usuario.AddAsync(datos);
            await dbContext.SaveChangesAsync();
            return Ok(datos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdUsuario(UsuarioModel datos)
        {
            
            await dbContext.SaveChangesAsync();
            return Ok(datos);
        }
    }
}
