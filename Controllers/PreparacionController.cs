
using System.Data.Common;
using System.IO.Compression;
using ApiValhalla.Context;
using System;
using Microsoft.AspNetCore.Mvc;

using ApiValhalla.Models;

namespace ApiValhalla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreparacionController : ControllerBase
    {
        private readonly AppDbContext _context;


        public PreparacionController(AppDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        [Route("IdPrepMax")]
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
        [Route("IdPrepCount")]
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
        [Route("AllPrep")]
        public ActionResult GetAllprep()
        {
            try
            {
                return Ok(_context.Preparacion.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpGet]
        [Route("PrepByTab/{id:int}")]
        public ActionResult Getprep(int id)
        {
            try
            {
                var result = from prepa in _context.Preparacion
                             join plat in _context.Platillo on prepa.Id_plat equals plat.Id_plat
                             where prepa.Id_mesa.Equals(id)
                             select new Models.ListaComand
                             {
                                 Id_prep = prepa.Id_prep,
                                 Platillo = plat.Nombre,
                                 Desc = plat.Descripcion,
                                 Canti = prepa.cantidad,
                                 Precio = prepa.Precio,
                                 Estado = prepa.Estado,
                                 Notas = prepa.Notas
                             };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("PrepTabUsu/{id:int}/{usu:int}")]
        public ActionResult Getprepusu(int id,int usu)
        {
            try
            {
                var result = from prepa in _context.Preparacion
                             join plat in _context.Platillo on prepa.Id_plat equals plat.Id_plat
                             where prepa.Id_mesa.Equals(id) && prepa.Id_usu.Equals(usu)
                             select new Models.ListaComand
                             {
                                 Id_prep = prepa.Id_prep,
                                 Platillo = plat.Nombre,
                                 Desc = plat.Descripcion,
                                 Canti = prepa.cantidad,
                                 Precio = prepa.Precio,
                                 Estado = prepa.Estado,
                                 Notas = prepa.Notas
                             };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpGet]
        [Route("PrepByMes/{id:int}")]
        public ActionResult getPrepMes(int id)
        {
            try
            {
                var result = from prepa in _context.Preparacion
                             join plat in _context.Platillo on prepa.Id_plat equals plat.Id_plat
                             where prepa.Id_mesa.Equals(id)
                             select prepa;
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);

            }
        }

        [HttpGet]
        [Route("PrepByone/{idprep:int}")]
        public ActionResult getPrepbyone(int idprep)
        {
            try
            {
                var result = _context.Preparacion.Where(o => o.Id_prep == idprep);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);

            }
        }



        [HttpGet]
        [Route("totprepby/{prep:int}")]
        public ActionResult Gettotprepby(int prep)
        {
            try
            {
                var result = _context.Preparacion.Where(c => c.Id_mesa == prep).Sum(e => e.Precio * e.cantidad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        //----------------------------- grabar --------------------------------------

        [HttpPost]
        [Route("AddPrep")]
        public ActionResult addPrep(PreparacionModel datos)
        {
            try
            {
                _context.Preparacion.Add(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("AddPrepV")]
        public ActionResult addPrepvario(List<PreparacionModel> datos)
        {
            try
            {
                foreach (var item in datos)
                {
                    _context.Preparacion.Add(item);
                    _context.SaveChanges();
                }
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }


        //---------------------modif -----------------------------------------------
        [HttpPut]
        [Route("UpdPrep")]
        public ActionResult updPrep(PreparacionModel datos)
        {
            try
            {
                _context.Preparacion.Update(datos);
                _context.SaveChanges();
                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("UpdAllPrep")]
        public ActionResult updAllPrep(List<PreparacionModel> datos)
        {
            try
            {
                foreach (var item in datos)
                {
                    _context.Preparacion.Update(item);
                    _context.SaveChanges();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }



        [HttpPut]
        [Route("UpdAllMesa")]
        public ActionResult updAllMesa(List<PreparacionModel> datos)
        {
            try
            {
                foreach (var item in datos)
                {
                    _context.Preparacion.Update(item);
                    _context.SaveChanges();
                }

                return Ok(datos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }



        [HttpDelete]
        [Route("Del1Prep/{id:int}")]
        public ActionResult delPrep(int id)
        {
            try
            {
                var prepa = new PreparacionModel { Id_prep = id };
                _context.Preparacion.Attach(prepa);
                _context.Preparacion.Remove(prepa);
                _context.SaveChanges();
                return Ok(prepa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex + "Estado =" + id);
            }


        }

        [HttpDelete]
        [Route("DelAllPrep/{id:int}")]
        public ActionResult DellallPrep(int id)
        {
            try
            {
                var tuplas = _context.Preparacion.Where(x => x.Id_mesa == id);
                string contenido = "";
                //return Ok(tuplas.ToList());
                foreach (var item in tuplas)
                {
                    var valor = new PreparacionModel { Id_prep = item.Id_prep };
                    contenido = (contenido + " - " + item.Id_prep.ToString());
                    //  _context.Preparacion.Attach(valor);

                    //_context.Preparacion.Remove(valor);
                    //_context.SaveChanges();
                }
                return Ok(contenido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }







    }
}