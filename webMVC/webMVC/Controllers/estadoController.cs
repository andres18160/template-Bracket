using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webMVC.Datos;

namespace webMVC.Controllers
{
    public class estadoController : ApiController
    {
        private PruebaFacturaConexion db = new PruebaFacturaConexion();

        // GET: api/estado
        public IQueryable<tb_estado> Gettb_estado()
        {
            return db.tb_estado;
        }

        // GET: api/estado/5
        [ResponseType(typeof(tb_estado))]
        public IHttpActionResult Gettb_estado(int id)
        {
            tb_estado tb_estado = db.tb_estado.Find(id);
            if (tb_estado == null)
            {
                return NotFound();
            }

            return Ok(tb_estado);
        }

        // PUT: api/estado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_estado(int id, tb_estado tb_estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_estado.id)
            {
                return BadRequest();
            }

            db.Entry(tb_estado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_estadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/estado
        [ResponseType(typeof(tb_estado))]
        public IHttpActionResult Posttb_estado(tb_estado tb_estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_estado.Add(tb_estado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_estado.id }, tb_estado);
        }

        // DELETE: api/estado/5
        [ResponseType(typeof(tb_estado))]
        public IHttpActionResult Deletetb_estado(int id)
        {
            tb_estado tb_estado = db.tb_estado.Find(id);
            if (tb_estado == null)
            {
                return NotFound();
            }

            db.tb_estado.Remove(tb_estado);
            db.SaveChanges();

            return Ok(tb_estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_estadoExists(int id)
        {
            return db.tb_estado.Count(e => e.id == id) > 0;
        }
    }
}