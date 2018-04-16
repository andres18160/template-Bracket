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
using WebApi.Datos;

namespace WebApi.Controllers
{
    public class facturaController : ApiController
    {
        private PruebaFacturaEntities1 db = new PruebaFacturaEntities1();

        // GET: api/factura
        public IQueryable<tb_factura> Gettb_factura()
        {
            return db.tb_factura;
        }

        // GET: api/factura/5
        [ResponseType(typeof(tb_factura))]
        public IHttpActionResult Gettb_factura(int id)
        {
            tb_factura tb_factura = db.tb_factura.Find(id);
            if (tb_factura == null)
            {
                return NotFound();
            }

            return Ok(tb_factura);
        }

        // PUT: api/factura/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_factura(int id, tb_factura tb_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_factura.NumeroFactura)
            {
                return BadRequest();
            }

            db.Entry(tb_factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_facturaExists(id))
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

        // POST: api/factura
        [ResponseType(typeof(tb_factura))]
        public IHttpActionResult Posttb_factura(tb_factura tb_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_factura.Add(tb_factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_factura.NumeroFactura }, tb_factura);
        }

        // DELETE: api/factura/5
        [ResponseType(typeof(tb_factura))]
        public IHttpActionResult Deletetb_factura(int id)
        {
            tb_factura tb_factura = db.tb_factura.Find(id);
            if (tb_factura == null)
            {
                return NotFound();
            }

            db.tb_factura.Remove(tb_factura);
            db.SaveChanges();

            return Ok(tb_factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_facturaExists(int id)
        {
            return db.tb_factura.Count(e => e.NumeroFactura == id) > 0;
        }
    }
}