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
    public class detalle_facturaController : ApiController
    {
        private PruebaFacturaConexion db = new PruebaFacturaConexion();

        // GET: api/detalle_factura
        public IQueryable<tb_detalle_factura> Gettb_detalle_factura()
        {
            return db.tb_detalle_factura;
        }

        // GET: api/detalle_factura/5
        [ResponseType(typeof(tb_detalle_factura))]
        public IHttpActionResult Gettb_detalle_factura(int id)
        {
            tb_detalle_factura tb_detalle_factura = db.tb_detalle_factura.Find(id);
            if (tb_detalle_factura == null)
            {
                return NotFound();
            }

            return Ok(tb_detalle_factura);
        }

        // PUT: api/detalle_factura/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_detalle_factura(int id, tb_detalle_factura tb_detalle_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_detalle_factura.Id)
            {
                return BadRequest();
            }

            db.Entry(tb_detalle_factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_detalle_facturaExists(id))
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

        // POST: api/detalle_factura
        [ResponseType(typeof(tb_detalle_factura))]
        public IHttpActionResult Posttb_detalle_factura(tb_detalle_factura tb_detalle_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_detalle_factura.Add(tb_detalle_factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_detalle_factura.Id }, tb_detalle_factura);
        }

        // DELETE: api/detalle_factura/5
        [ResponseType(typeof(tb_detalle_factura))]
        public IHttpActionResult Deletetb_detalle_factura(int id)
        {
            tb_detalle_factura tb_detalle_factura = db.tb_detalle_factura.Find(id);
            if (tb_detalle_factura == null)
            {
                return NotFound();
            }

            db.tb_detalle_factura.Remove(tb_detalle_factura);
            db.SaveChanges();

            return Ok(tb_detalle_factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_detalle_facturaExists(int id)
        {
            return db.tb_detalle_factura.Count(e => e.Id == id) > 0;
        }
    }
}